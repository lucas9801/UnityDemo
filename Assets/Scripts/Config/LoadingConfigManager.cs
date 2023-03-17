
public class LoadingConfigManager
{
    private static LoadingConfigManager m_instance;

    public static LoadingConfigManager Instance
    {
        get
        {
            if (null == m_instance) m_instance = new LoadingConfigManager();
            return m_instance;
        }
    }

    public LoadingConfig config;

    public bool IsUseAB()
    {
#if UNITY_EDITOR
        return null == config ? true : config.UseAB;
#else
        return true;
#endif
    }
}

public class LoadingConfig
{
    //是否是用AB加载
    public bool UseAB;
}
