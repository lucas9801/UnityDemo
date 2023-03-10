using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;
using Assembly = System.Reflection.Assembly;
using Object = UnityEngine.Object;

public class HybridManager : MonoBehaviour
{
    private static HybridManager m_instance;

    public static HybridManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    private void Awake()
    {
        if (m_instance != null)
        {
            DebugL8.LogError("初始化多份HybridManager");
            return;
        }
        m_instance = this;
        
        //加载热更Dll
        StartCoroutine(LoadHotFixAssembly());
    }

    IEnumerator LoadHotFixAssembly()
    {
#if UNITY_ANDROID
        
#else
        UnityWebRequest req = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/HybridCLRData" + "/Assembly-CSharp.dll");
#endif
        yield return req.SendWebRequest();
        if (!string.IsNullOrEmpty(req.error))
        {
            DebugL8.LogError(req.error);
            yield break;
        }

        byte[] dll = req.downloadHandler.data;
        System.Reflection.Assembly ass = System.Reflection.Assembly.Load(dll);
        req.Dispose();
        OnHotFixedLoad(ass);
    }

    private void OnHotFixedLoad(Assembly assembly)
    {
        Type entryType = assembly.GetType("HybridHotFix");
        MethodInfo method = entryType.GetMethod("Test");
        method.Invoke(null, null);


        // Object obj = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Res/FrameWork/ILRuntimeManager.prefab", typeof(Object));
        // Instantiate(obj);
    }
}
