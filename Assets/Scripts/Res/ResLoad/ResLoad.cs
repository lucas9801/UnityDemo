using System;
using System.IO;
using AssetBundles;
using CommonEditorTools;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Res.ResLoad
{
    public class ResLoad
    {
        public static Object LoadRes(string path, Type type = null)
        {
            if (string.IsNullOrEmpty(path)) return null;
            GetLocalizationPath(ref path);
            if (null == type) type = typeof(Object);
            Object obj;
            if (LoadingConfigManager.Instance.IsUseAB()) return BaseAssetPool.Instance.LoadAsset(path, type);

            return AssetDatabase.LoadAssetAtPath(path, type);
        }

        private static void GetLocalizationPath(ref string path)
        {
            if (path.StartsWith("Assets/Res/UI/Texture") || path.StartsWith("Assets/Res/UI/Font"))
            {
                string localPath = LanguageManager.Instance.GetLocalizationPath(path);
                if (HasAsset(localPath)) path = localPath;
            }
        }

        public static bool HasAsset(string path)
        {
#if UNITY_EDITOR
            if (!LoadingConfigManager.Instance.IsUseAB())
            {
                return File.Exists(path);
            }
#endif
            string bundleName = CommonUtility.GetBundleName(path);
            return AssetBundleManager.Instance.HasBundle(bundleName);
        }
    }
}