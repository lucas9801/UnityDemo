using System.Collections.Generic;
using CommonEditorTools;
using UnityEditor;
using UnityEngine;

public class AssetBundleUtils
{
    /// <summary>
    /// 获取图集的AB包名
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="allBuildDic"></param>
    /// <param name="processAsset"></param>
    public static void CollectABNameOfAtlas(Object obj, Dictionary<string, AssetBundleBuild> allBuildDic, List<string> processAsset)
    {
        var path = AssetDatabase.GetAssetPath(obj);
        string[] paths = path.Split('/');
        CollectOneABItem(path, CommonUtility.GetAtlasABName(paths[paths.Length - 2]), allBuildDic);
    }
    
    /// <summary>
    /// 有依赖的资源
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="allBuildDic"></param>
    /// <param name="processAsset"></param>
    public static void CollectABNameWithDependence(Object obj, Dictionary<string, AssetBundleBuild> allBuildDic, List<string> processAsset)
    {
        string path = AssetDatabase.GetAssetPath(obj);
        InnerCollectABWithDependence(path, CommonUtility.GetBundleName(path), allBuildDic, processAsset);
    }

    /// <summary>
    /// 原生资源打包
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="allBuildDic"></param>
    /// <param name="processAsset"></param>
    public static void CollectABNameWithOutDependence(Object obj, Dictionary<string, AssetBundleBuild> allBuildDic, List<string> processAsset)
    {
        string path = AssetDatabase.GetAssetPath(obj);
        processAsset.Add(path);
        CollectOneABItem(path, CommonUtility.GetBundleName(path), allBuildDic);
    }

    /// <summary>
    /// mark资产和其依赖
    /// </summary>
    /// <param name="path"></param>
    /// <param name="tag"></param>
    /// <param name="allBuildDic"></param>
    /// <param name="processAsset"></param>
    /// <param name="root"></param>
    public static void InnerCollectABWithDependence(string path, string tag, Dictionary<string, AssetBundleBuild> allBuildDic, List<string> processAsset, string root = null)
    {
        string lowerPath = path.ToLower();
        if (lowerPath.EndsWith(".cs") || lowerPath.EndsWith(".dll") || lowerPath.EndsWith(".shader") ||
            lowerPath.StartsWith("assets/res/ui/textuers/") || string.IsNullOrEmpty(tag) ||
            processAsset.Contains(path)) return;
        
        processAsset.Add(path);
        CollectOneABItem(path, tag, allBuildDic);
        //图集不需要找依赖
        if (path.EndsWith(".spriteatlas")) return;

        //获取依赖资产路径
        var dependencies = AssetDatabase.GetDependencies(path, false);
        foreach (var dependency in dependencies)
        {
            lowerPath = dependency.ToLower();
            if (lowerPath.EndsWith(".cs") || lowerPath.EndsWith(".dll")) continue;
            if (dependencies.Equals(path))
            {
                EditorUtility.DisplayDialog("Error", string.Format("发现循环依赖:\n{0}\n{1}", path, root), "确定");
                DebugL8.LogError("Fetal Error: loop dependencies");
            }

            string bundleName = CommonUtility.GetBundleName(dependency);
            InnerCollectABWithDependence(dependency, bundleName, allBuildDic, processAsset);
        }
    }

    /// <summary>
    /// mark资产
    /// </summary>
    /// <param name="path"></param>
    /// <param name="tag"></param>
    /// <param name="abItems"></param>
    private static void CollectOneABItem(string path, string tag, Dictionary<string, AssetBundleBuild> abItems)
    {
        if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(tag) || null == abItems) return;

        AssetBundleBuild build;
        if (!abItems.TryGetValue(tag, out build)) build = new AssetBundleBuild();
        build.assetBundleName = tag;
        if (null == build.assetNames) build.assetNames = new string[] { path };
        else
        {
            bool exist = false;
            foreach (var name in build.assetNames)
            {
                if (name == tag)
                {
                    exist = true;
                    break;
                }
            }

            if (!exist)
            {
                string[] oldArray = build.assetNames;
                build.assetNames = new string[build.assetNames.Length + 1];
                build.assetNames[0] = path;
                oldArray.CopyTo(build.assetNames, 1);
            }
        }

        abItems[tag] = build;
    }
    
}