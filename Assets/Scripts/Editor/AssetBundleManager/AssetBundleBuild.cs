/*
 class: AssetBundleBuilder.cs
 author: solo
 function: Automated packaging AB
 1.标记AB
 2.根据标记遍历
 */
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonEditorTools;
using UnityEditor;
using UnityEngine;

public static class AssetBundleBuilder
{
    public static readonly string m_outPath = Application.streamingAssetsPath + "/AssetsBundles";
    
    
    public class ABMarkItem
    {
        public string Path;
        public System.Func<string, bool> Filter;
        public string Name;
    }

    private static Dictionary<string, AssetBundleBuild> m_allBuildDic = new Dictionary<string, AssetBundleBuild>(4096);

    [MenuItem("Build/AssetBundle/Win平台")]
    private static void BuildAssetBundle()
    {
        if (!Directory.Exists(m_outPath)) Directory.CreateDirectory(m_outPath);
        MarkBuildSymbol();
        var manifest = BuildPipeline.BuildAssetBundles(m_outPath, m_allBuildDic.Values.ToArray(),
            BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.DeterministicAssetBundle,
            BuildTarget.StandaloneWindows);
        if (null != manifest) EditorUtility.DisplayDialog("Tip", "打包完成", "确定"); 
    }

    /// <summary>
    /// 自动MarkAB
    /// </summary>
    private static void MarkBuildSymbol()
    {
        List<ABMarkItem> markList = new List<ABMarkItem>()
        {
            new ABMarkItem { Path = "Assets/Res/FrameWork", Filter = name => name.EndsWith(".prefab") },
            new ABMarkItem { Path = "Assets/Res/UI", Filter = name => name.EndsWith(".prefab") },
        };
        List<string> processAsset = new List<string>();

        foreach (var item in markList)
        {
            CommonUtility.LoopAllUnityObjectsInFolder(item.Path,
                obj => AssetBundleUtils.CollectABNameWithDependence(obj, m_allBuildDic, processAsset));
        }

        CommonUtility.LoopAllUnityObjectsInFolder("Assets/Res/UI/Textuers",
            obj => AssetBundleUtils.CollectABNameOfAtlas(obj, m_allBuildDic, processAsset));
    }
    
    


}