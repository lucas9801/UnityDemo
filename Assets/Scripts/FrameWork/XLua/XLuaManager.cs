/*
 *  文件：XLuaManager.cs
 *  功能:XLua管理器
 *  作者：solo
 */
using UnityEngine;
using XLua;
using System;
using System.IO;
using System.Text;

public class XLuaManager : MonoBehaviour
{
    private static XLuaManager m_instance;

    public static XLuaManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    /// <summary>
    /// lua虚拟机 全局唯一
    /// </summary>
    private LuaEnv m_luaEnv;

    /// <summary>
    /// lua入口文件
    /// </summary>
    private LuaTable m_mainLua = null;

    /// <summary>
    /// MainLua中Update
    /// </summary>
    private Action<LuaTable> m_luaMainUpdate;

    /// <summary>
    /// lua虚拟机GC间隔 秒
    /// </summary>
    private const float GCInterval = 1;

    /// <summary>
    /// 上次GC的时间
    /// </summary>
    private static float LastGCTime = 0;

    public LuaEnv LuaEnv
    {
        get
        {
            return m_luaEnv;
        }
    }

    private string m_luaRootPath = string.Empty;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (m_instance != null)
        {
            DebugL8.LogError("XLua初始化多份");
            return;
        }

        DebugL8.Log("XLuaManager初始化成功");
#if UNITY_EDITOR
        m_luaRootPath = Application.streamingAssetsPath + "/Lua/";
#else

#endif
        m_instance = this;
        m_luaEnv = new LuaEnv();
        m_luaEnv.GcPause = 100;
        //增加三方库
        m_luaEnv.AddBuildin("memstream", XLua.LuaDLL.Lua.LoadMemStream);
        m_luaEnv.AddLoader(CustomLuaLoaderMethod);

        object[] ret = m_luaEnv.DoString(GetLuaFileBytes("MainLua"), "MainLua", null);
        if (ret == null || ret.Length <= 0 )
        {
            DebugL8.LogError("Mainlua文件执行出错");
            return;
        }
        m_mainLua = ret[0] as LuaTable;
        m_mainLua.Get("Update", out m_luaMainUpdate);
    }

    private void Update()
    {
        if (m_luaMainUpdate != null && m_mainLua != null)
        {
            try
            {
                m_luaMainUpdate(m_mainLua);
            }
            catch (Exception e)
            {
                DebugL8.LogError(e);
            }

            if (LastGCTime + GCInterval < Time.realtimeSinceStartup)
            {
                //清一下ObjectPool中缓存的C#对象
                m_luaEnv.Tick();
                LastGCTime = Time.realtimeSinceStartup;
            }
        }
    }

    private void OnDestroy()
    {
        m_mainLua = null;
        m_luaMainUpdate = null;
        m_luaEnv = null;
    }

    /// <summary>
    /// 自定义加载器
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public byte[] CustomLuaLoaderMethod(ref string fileName)
    {
        return GetLuaFileBytes(fileName);
    }

    public byte[] GetLuaFileBytes(string fileName)
    {
        try
        {
            if (string.IsNullOrEmpty(fileName))
            {
                DebugL8.Log("Lua Require参数为空！");
                return null;
            }

            //屏蔽一下EmmyLua
            if (fileName == "emmy_core")
            {
                return null;
            }

            if (fileName.IndexOf(".lua") <= -1) fileName += ".lua";
                
            byte[] ret;
            ret = File.ReadAllBytes(m_luaRootPath + fileName);
            
            return ret;

        }
        catch (Exception e)
        {
            DebugL8.LogError(e);
        }

        return null;
    }
    
}
