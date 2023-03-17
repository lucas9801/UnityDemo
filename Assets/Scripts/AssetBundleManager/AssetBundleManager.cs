using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

namespace AssetBundles
{
    public class AssetBundleManager : IDisposable
    {
        private static AssetBundleManager m_instance;

        public static AssetBundleManager Instance
        {
            get
            {
                if (m_instance == null) m_instance = new AssetBundleManager();
                return m_instance;
            }
        }

        public enum PrioritizationStrategy
        {
            PrioritizeRemote,
            PrioritizeStreamingAssets,
        }

        public bool Initialized { get; private set; }
        
        public AssetBundleManifest Manifest { get; private set; }
        
        public CustomAssetBundleManifest CustomManifest { get; private set; }

        public bool Usehash;
        private PrioritizationStrategy m_defaultPrioritizationStrategy;
        // private ICommandHandle<Ass>


        public AssetBundle LoadAssetBundle(string bundleName)
        {
            return null;
        }

        public void LoadAssetBundleAsync(string bundleName, Action<AssetBundle> onComplete)
        {
            
        }

        public AssetBundle LoadAssetBundleWhichWeBelieveAlreadyExist(string bundleName)
        {
            return null;
        }

        public void UnLoadBundle(string bundleName, bool unLoadAllLoaderObjects = true, bool force = false)
        {
            
        }

        public bool HasBundle(string bundleName)
        {
            return null != CustomManifest && CustomManifest.Bundles.Contains(bundleName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}