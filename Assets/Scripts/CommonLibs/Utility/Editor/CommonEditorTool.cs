using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CommonEditorTools
{
    public static class CommonUtility
    {
        //图集路径
        public static string s_packedTextureRootPath = "Assets/Res/UI/Texture/";
        private static int s_packedTextureRootPathLength = s_packedTextureRootPath.Length;
        private static Dictionary<string, string> s_path2ABNameDic = new Dictionary<string, string>(4096 * 10, CustomOrdinalStringComparer.GetComparer());

        /// <summary>
        /// 获取ABName
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetBundleName(string path)
        {
            string abName;
            if (s_path2ABNameDic.TryGetValue(path, out abName)) return abName;

            if (path.IndexOf(s_packedTextureRootPath) == 0)
            {
                int idx = path.IndexOf("/", s_packedTextureRootPathLength);
                abName = GetAtlasABName(path.Substring(s_packedTextureRootPathLength,
                    idx - s_packedTextureRootPathLength));
                s_path2ABNameDic.Add(path, abName);
                return abName;
            }

            abName = MD5FilesGenerator.GetMd5Hash(abName);
            s_path2ABNameDic.Add(path, abName);
            return abName;
        }
        
        /// <summary>
        /// 获取图集ABName
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public static string GetAtlasABName(string folderName)
        {
            return "atlas" + folderName;
        }

#if UNITY_EDITOR

        /// <summary>
        /// 遍历文件夹内File
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="processAction"></param>
        /// <param name="filter"></param>
        /// <param name="showTips"></param>
        /// <returns></returns>
        public static bool LoopAllUnityObjectsInFolder(string relativePath, Action<Object> processAction, Func<string, bool> filter = null, bool showTips = false)
        {
            if (!IsFolder(relativePath))
            {
                if (showTips)
                    EditorUtility.DisplayDialog("Error", string.Format("路径{0}不合法，请选择文件夹进行操作", relativePath), "确定");
                return false;
            }
            else
            {
                if (!showTips || EditorUtility.DisplayDialog("Tip", string.Format("即将对{0}进行操作", relativePath), "确定", "取消"))
                {
                    var dir = ToAbsolatePath(relativePath);
                    if (!Directory.Exists(dir)) return false;
                    LoopAllUnityObjectsInFolderRecursive(dir, processAction, filter);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        /// <summary>
        /// 遍历文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <param name="processAction"></param>
        /// <param name="filter"></param>
        public static void LoopAllUnityObjectsInFolderRecursive(string path, Action<Object> processAction, Func<string, bool> filter)
        {
            var directories = Directory.GetDirectories(path);
            foreach (var dir in directories)
            {
                LoopAllUnityObjectsInFolderRecursive(dir, processAction, filter);
            }

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (null != filter && !filter(file)) return;
                if (!file.EndsWith(".meta"))
                {
                    var obj = AssetDatabase.LoadMainAssetAtPath(file.ToRelativePath());
                    if (null != processAction) processAction(obj);
                }
            }
        }

        /// <summary>
        /// 相对路径转绝对路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToAbsolatePath(this string path)
        {
            
            return path.Replace("Assets", Application.dataPath).Replace("\\", "/"); 
            // var assetLength = "Assets".Length;
            // return Application.dataPath + path.Substring(assetLength, path.Length - assetLength).Replace("\\", "/");
        }

        /// <summary>
        /// 绝对路径转相对路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToRelativePath(this string path)
        {
            return path.Replace(Application.dataPath, "Assets").Replace("\\", "/");
        }
        
        /// <summary>
        /// 是不是Prefab
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsPrefab(Object obj)
        {
            return null != obj && PrefabUtility.GetPrefabAssetType(obj) != PrefabAssetType.NotAPrefab;
        }
        
        /// <summary>
        /// 路径是否合法
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFolder(this string path)
        {
            var type = AssetDatabase.GetMainAssetTypeAtPath(path);
            if (type != typeof(DefaultAsset)) return false;
            return Directory.Exists(ToAbsolatePath(path));
        }

        /// <summary>
        /// MipMap开关
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="mipMapEnable"></param>
        public static void UnCheckMipMap(Object obj, bool mipMapEnable)
        {
            var texture = obj as Texture;
            if (null == texture) return;
            var importer = GetAssetImporter(obj) as TextureImporter;
            if (null != importer) importer.mipmapEnabled = mipMapEnable;
        }
        
        /// <summary>
        /// 获取AssetImporter
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static AssetImporter GetAssetImporter(Object obj)
        {
            var path = AssetDatabase.GetAssetPath(obj);
            var importer = AssetImporter.GetAtPath(path);
            if (null == importer) DebugL8.LogError("Importer form {0} is null", path);
            return importer;
        }

        /// <summary>
        /// 设置Texture压缩方式
        /// </summary>
        /// <param name="importer"></param>
        /// <param name="compression"></param>
        public static void SetTextureCompression(TextureImporter importer, TextureImporterCompression compression)
        {
            if (null != importer) importer.textureCompression = compression;
        }

        [MenuItem("Assets/拷贝路径")]
        private static void CopyPath()
        {
            GUIUtility.systemCopyBuffer = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
        }
#endif
        
    }
}