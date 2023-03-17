using System;
using System.Collections.Generic;
using Codice.Client.BaseCommands.Merge;
using Codice.Client.Common;
using CommonEditorTools;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Object = UnityEngine.Object;
using Time = UnityEngine.Time;

namespace AssetBundles
{
    /// <summary>
    /// 对于同一个asset，只应该去ABload一次，也就是对这个ab只有一个ref。
    /// 但是如果同时存在异步+同步加载同一个资源的时候，由于同步不能等异步，所以必须立即去ABload一次，
    /// 导致一个asset对ab加了2个ref，所以这种情况需要回调的时候减去1个。（LoadComplelte里已经处理）
    /// 
    /// 
    /// 用weakreference来看asset是否应被回收，被回收的话则可以释放掉。
    /// 但是有一个特例，就是GameObejct类型，这个类型的asset load出来之后都是需要实例化来使用的
    /// 实例化之后，如果没有变量引用原来的asset(prefab)，那么asset会在resource.unloadunusedasset时被回收
    /// 但是我们如果这时候去释放asset和对应ab，那么实例化之后的GO对应的资源也没了，因为我们使用了ab.unload(true)
    /// 所以对于GameObject（prefab）类型，需要根据实例化数量来增加一个计数来协助检查资源（也就是refcount+weakref方案）
    /// 
    /// /** 此部分只针对Editor下
    /// 但是，如果我们对这个prefab动态加上了脚本（refcount），那么这个prefab将无法被resource.unloadunusedasset回收，
    /// 导致对应的资源泄露。
    /// 所以我们对这种类型直接采用refcount方案，去掉weakref方案。
    /// **/
    /// 
    /// 如果我们的weakref引用了一个asset，但是我们调用了直接卸载的借口，将对应的ab unload(true)了（例如直接释放atlas），
    /// 那么这时候weakref对应的Target不是null，而是"null"，由于Target类型是object，而不是UnityEngine.Object,所以这里的
    /// weakref.Target == null不成立（但是UnityEngine.Object的话就成立，因为==被重写），所以我们要在直接卸载某个资源的时候，
    /// 同时遍历检查一下是否有asset变成"null"了，如果变了，就得立即移除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseAssetPool : IDisposable
    {
        private static BaseAssetPool m_instance;

        public static BaseAssetPool Instance
        {
            get
            {
                if (null == m_instance) m_instance = new BaseAssetPool();
                return m_instance;
            }
        }

        //存储未实例化资源对象的集合，加载和卸载自动处理
        private Dictionary<string, WeakReference> m_assetPool = new Dictionary<string, WeakReference>(CustomOrdinalStringComparer.GetComparer());

        private Dictionary<string, int> m_prefabRefCount = new Dictionary<string, int>(1024, CustomOrdinalStringComparer.GetComparer());

        private List<string> m_removeKeys = new List<string>();

        private Dictionary<string, AssetLoadOperation> m_loadingOperation = new Dictionary<string, AssetLoadOperation>(CustomOrdinalStringComparer.GetComparer());

        private float m_lastUpdateTime = -1;

        private BaseAssetPool()
        {
            UpdateManager.RegisterUpdate(Update);
        }

        private void Update()
        {
            if (Time.realtimeSinceStartup - m_lastUpdateTime > 1.5f) CheckAndUnLoadAssets();
        }

        /// <summary>
        /// 检查并清理资源
        /// </summary>
        private void CheckAndUnLoadAssets()
        {
            m_lastUpdateTime = Time.realtimeSinceStartup;
            WeakReference weak;
            m_removeKeys.Clear();
            foreach (string key in m_assetPool.Keys)
            {
                weak = m_assetPool[key];
                if (null != weak && (null == weak.Target || null == (weak.Target as Object)))
                {
#if UNITY_EDITOR
                    m_removeKeys.Add(key);
#else
                    
#endif
                    for (int i = 0; i < m_removeKeys.Count; i++)
                    {
                        UnLoadAssets(m_removeKeys[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 移除资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="force"></param>
        public void UnLoadAssets(string assetName, bool force = false)
        {
            if (m_assetPool.ContainsKey(assetName))
            {
                WeakReference weak = m_assetPool[assetName];
                if (null != weak && null != weak.Target && null != weak.Target as Object)
                {
                    if (!(weak.Target is GameObject)) Resources.UnloadAsset(weak.Target as Object);
                }

                m_assetPool.Remove(assetName);
                AssetBundleManager.Instance.UnLoadBundle(CommonUtility.GetBundleName(assetName), true, force);
            }
        }

        /// <summary>
        /// 卸载Atlas
        /// </summary>
        /// <param name="atlasName"></param>
        public void UnLoadAtlas(string atlasName)
        {
            if (string.IsNullOrEmpty(atlasName)) return;
            DebugL8.Log("卸载Atlas：{0}", atlasName);
            AssetBundleManager.Instance.UnLoadBundle(CommonUtility.GetAtlasABName(atlasName), true, true);
            CheckAndUnLoadAssets();
        }
        
        /// <summary>
        /// 同步加载资源
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Object LoadAsset(string path, Type type)
        {
            if (string.IsNullOrEmpty(path))
            {
                DebugL8.LogError("Load a null or empty asset");
                return null;
            }

            if (null == type) type = typeof(Object);
            Object obj = GetAsset(path, type);
            if (null != obj) return obj;
            if (m_loadingOperation.ContainsKey(path)) DebugL8.LogWarning("同时同步+异步加载资源{0}", path);
            string bundleName = CommonUtility.GetBundleName(path);
            AssetBundle ab = AssetBundleManager.Instance.LoadAssetBundle(bundleName);
            LoadBundleComolete(ab, path, type, true);
            return GetAsset(path, type);
        }

        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public AssetLoadOperation LoadAssetAsync(string path, Type type, Action cb)
        {
            if (string.IsNullOrEmpty(path))
            {
                DebugL8.LogError("Load a empty or null asset:{0}", path);
                return null;
            }
            if (null == type) type = typeof(Object);

            if (null != GetAsset(path, type))
            {
                DebugL8.Log("在pool中找到了asset：{0}", path);
                AssetLoadOperation op = new AssetLoadOperation(path, type, cb);
                op.IsDone = true;
                if (null != cb) cb();
                return op;
            }
            else
            {
                DebugL8.Log("在pool中没找到asset，进入加载流程：{0}", path);
                AssetLoadOperation op;
                if (m_loadingOperation.TryGetValue(path, out op))
                {
                    DebugL8.Log("正在异步加载资源");
                    op.m_callBack += cb;
                    return op;
                }
                else
                {
                    op = new AssetLoadOperation(path, type, cb);
                    m_loadingOperation.Add(path, op);
                }

                AssetBundleManager.Instance.LoadAssetBundleAsync(op.m_bundleName, ab =>
                {
                    LoadBundleComolete(ab, op.m_assetName, op.m_type, false);
                });
                return op;
            }
        }

        /// <summary>
        /// bundle加载完成后的回调
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <param name="isSync"></param>
        private void LoadBundleComolete(AssetBundle ab, string path, Type type, bool isSync)
        {
            if (null == ab)
            {
                DebugL8.LogError("bundle {0}\n{1} load failed", CommonUtility.GetBundleName(path), path);
                LoadAssetComplete(path, null, type);
            }
            else
            {
                if (isSync)
                {
                    Object obj = ab.LoadAsset(path, type);
                    LoadAssetComplete(path, obj, type);
                }
                else
                {
                    AssetBundleRequest req = ab.LoadAssetAsync(path, type);
                    req.completed += (asyncOp) =>
                    {
                        AssetLoadOperation op;
                        if (m_loadingOperation.TryGetValue(path, out op))
                            LoadAssetComplete(op.m_assetName, req.asset, op.m_type);
                        else 
                            DebugL8.LogError("AB异步加载后没有找到对应的asset加载请求：\n abName:{0}\n assetName{1}", ab.name, path);
                    };
                }
            }
        }

        /// <summary>
        /// 从AB中成功加载Asset后的回调
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        private void LoadAssetComplete(string path, Object obj, Type type)
        {
            if (null == obj) 
                DebugL8.LogError("资源加载失败：{0}", path);
            else
            {
                WeakReference weak;
                if (!m_assetPool.TryGetValue(path, out weak))
                {
                    weak = new WeakReference(obj, false);
                    m_assetPool[path] = weak;
                    DebugL8.Log("{0}加载成功", path);
                }
                else
                {
                    ///如果遇到这种情况，只有一种可能。这个资源同时进行了异步+同步加载，同步返回了asset，当异步再次返回的时候，就会走到这里。
                    ///当然还有一个前提，那就是在加载之前的GetAsset里已经把weak存在(target存在或者不存在都可以)的情况处理好直接返回了
                    DebugL8.LogWarning("正常加载回调不应该有weak已经存在，因为加载之前的GetAsset应该已经处理过这种情况了");
                    weak.Target = obj;
                    //由于对同一个asset进行了两次abload，也就加了两次引用，所以这里要删除一次，否则会导致ab泄露
                    AssetBundleManager.Instance.UnLoadBundle(path);
                }

                CheckGameObjectType(path, type, obj);
            }
        }

        /// <summary>
        /// 使用自动引用计数脚本协助弱引用实现资源管理
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        private void CheckGameObjectType(string path, Type type, Object obj)
        {
            if (null == obj) return;
            if (type == typeof(GameObject) || path.EndsWith(".prefab"))
            {
                GameObject go = obj as GameObject;
                AssetBundleRefCounter counter = go.GetComponent<AssetBundleRefCounter>();
                if (null == counter) counter = go.AddComponent<AssetBundleRefCounter>();

                counter.InitRefInfo(path);
            }
        }

        /// <summary>
        /// 获取GameObject引用计数
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private int GetPrefabRef(string path)
        {
            int cnt = 0;
            m_prefabRefCount.TryGetValue(path, out cnt);
            return cnt;
        }

        /// <summary>
        /// GameObject实例化引用计数
        /// </summary>
        /// <param name="path"></param>
        public void AddPrefabRef(string path)
        {
            int cnt = 0;
            m_prefabRefCount.TryGetValue(path, out cnt);
            m_prefabRefCount[path] = ++cnt;
        }
        
        /// <summary>
        /// 减少GameObject引用计数
        /// </summary>
        /// <param name="path"></param>
        public void ReleasePrefabRef(string path)
        {
            int cnt = 0;
            if (m_prefabRefCount.TryGetValue(path, out cnt))
            {
                //去销毁
                if (0 >= --cnt)
                {
                    m_prefabRefCount.Remove(path);
                    WeakReference weak;
                    if (m_assetPool.TryGetValue(path, out weak))
                    {
                        weak.Target = null;
                        UnLoadAssets(path);
                    }
                    else
                    {
                        DebugL8.Log("pool中没有找到对应资源：{0}", path);   
                    }
                }
                else
                {
                    m_prefabRefCount[path] = cnt;
                }
            }
            else
            {
                DebugL8.LogError("引用计数错误：{0}", path);
            }

        }
        
        /// <summary>
        /// 从池子里面拿Asset
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Object GetAsset(string path, Type type)
        {
            if (!m_assetPool.ContainsKey(path))
            {
                DebugL8.Log("pool中没有资源：{0}", path);
                return null;
            }

            WeakReference weak = m_assetPool[path];
            if (null == weak)
            {
                DebugL8.LogError("不应该出现key->null的情况，应该是key->weak,weak->target = null");
                DebugL8.LogError("assetName");
                m_assetPool.Remove(path);
                return null;
            }

            if (null == weak.Target)
            {
                DebugL8.Log("asset被GC,但是还没有被Update逻辑释放，{0}", path);

                AssetBundle ab =
                    AssetBundleManager.Instance.LoadAssetBundleWhichWeBelieveAlreadyExist(
                        CommonUtility.GetBundleName(path));
                if (null == ab)
                {
                    DebugL8.LogError("{0} asset's ab is not exist", path);
                    UnLoadAssets(path);
                    return null;
                }
                else
                {
                    weak.Target = ab.LoadAsset(path, type);
                    CheckGameObjectType(path, type, weak.Target as Object);
                }
            }
            return weak.Target as Object;
        }
        
        public void Dispose()
        {
           m_assetPool.Clear();
           m_prefabRefCount.Clear();
           m_loadingOperation.Clear();
           UpdateManager.UnRegisterUpdate(Update);
        }
    }

    public class AssetLoadOperation
    {
        public string m_assetName;
        public string m_bundleName;
        public Type m_type;
        public bool IsDone;
        public Action m_callBack;

        public AssetLoadOperation(string assetName, Type type, Action cb)
        {
            m_assetName = assetName;
            m_bundleName = CommonUtility.GetBundleName(assetName);
            m_type = type;
            IsDone = false;
            m_callBack = cb;
        }
    }
}