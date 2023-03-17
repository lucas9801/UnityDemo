using System.Collections.Generic;

namespace AssetBundles
{
    public class CustomAssetBundleManifest
    {
        /// <summary>
        /// 所有Bundle名字的集合
        /// </summary>
        public List<string> Bundles = new List<string>(ushort.MaxValue);

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string[]> Maps = new Dictionary<string, string[]>(ushort.MaxValue, CustomOrdinalStringComparer.GetComparer());
    }
}