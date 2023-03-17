using System;
using UnityEngine;

namespace AssetBundles
{
    public class AssetBundleRefCounter :MonoBehaviour
    {
        private string m_assetName = string.Empty;

        public void InitRefInfo(string path)
        {
            this.m_assetName = path;
        }

        private void Awake()
        {
            if (string.IsNullOrEmpty(m_assetName))
            {
                DebugL8.LogError("资源信息错误, assetName:{0}", m_assetName);
                return;
            }

            BaseAssetPool.Instance.AddPrefabRef(m_assetName);
        }

        private void OnDestroy()
        {
            BaseAssetPool.Instance.ReleasePrefabRef(m_assetName);
        }
    }
}