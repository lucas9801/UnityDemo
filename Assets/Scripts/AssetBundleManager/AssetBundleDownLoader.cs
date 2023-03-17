using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssetBundles
{
    public struct ABItem
    {
        public string Md5;
        public string BlockName;
        public uint Offset;
        public uint Length;
    }

    public struct AssetBundleDownLoadCommand
    {
        public bool Async;
        public string BundleName;
        public Action<AssetBundle> OnComplete;
    }

    public class AssetBundleDownLoader : ICommandHandle<AssetBundleDownLoader>
    {
        private static Dictionary<string, ABItem> m_innerABMap;
        public static Dictionary<string, ABItem> InnerABMap
        {
            set
            {
                m_innerABMap = value;
            }
        }

        private static Dictionary<string, string> m_patchedABList;
        public static Dictionary<string, string> PatchABList
        {
            set
            {
                m_patchedABList = value;
            }
        }

        private static Dictionary<string, string> m_blockName2Path = new Dictionary<string, string>(2048, CustomOrdinalStringComparer.GetComparer());
        private static Dictionary<string, string> m_abName2Path = new Dictionary<string, string>(2048, CustomOrdinalStringComparer.GetComparer());

        private static string m_innerPath;
        public static string InnerPath
        {
            set
            {
                m_innerPath = value;
            }
        }

        private static string m_pathedPath;
        public static string PathedPath
        {
            set
            {
                m_pathedPath = value;
            }
        }
        
        

        public void Handle(AssetBundleDownLoader loader)
        {
            
        }
    }
}