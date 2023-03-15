namespace AssetBundles
{
    public class AssetBundleManager
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
        
        
        
    }
}