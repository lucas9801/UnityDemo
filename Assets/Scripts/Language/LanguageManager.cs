using System.Collections.Generic;
using Unity.Scenes;
using UnityEngine;

public class LanguageManager
{
    private static LanguageManager m_instance = null;

    public static LanguageManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new LanguageManager();
                m_instance.LoadBuildinTranslate();
            }

            return m_instance;
        }
    }

    /// <summary>
    /// 翻译表Key
    /// </summary>
    public const string BaseLan = "chs";

    public const string BaseLanFolderName = "/chs/";

    public const string LanguageKey = "Language";

    /// <summary>
    /// 主要用于资源路径中本地化文件夹的替换
    /// </summary>
    public string m_curLanguageFolderName = "/cht/";

    public string CurLanguageFolderName
    {
        get
        {
            return m_curLanguageFolderName;
        }
    }

    private string m_curLanguage;

    public string CurLanguage
    {
        get
        {
            if (string.IsNullOrEmpty(m_curLanguage))
            {
                m_curLanguage = PlayerPrefs.GetString(LanguageKey, "");
                m_curLanguageFolderName = "/" + m_curLanguage + "/";
            }
            return m_curLanguage;
        }
        set
        {
            m_curLanguage = value;
            m_curLanguageFolderName = "/" + m_curLanguage + "/";
            PlayerPrefs.SetString(LanguageKey, m_curLanguage);
        }
    }

    private Dictionary<string, string> m_buildinDic = new Dictionary<string, string>();

    /// <summary>
    /// 多语言字体对象字典，key为字体路径
    /// </summary>
    private Dictionary<string, Font> m_multiFontObjectDic = new Dictionary<string, Font>();

    /// <summary>
    /// 多语言字体替换
    /// </summary>
    /// <param name="fontName"></param>
    /// <returns></returns>
    public Font MultilnaguageFontReplace(string fontName)
    {
        if (!Application.isPlaying) return null;
        //获取font资源路径
        string fontPath = "xf001_font1";
        string assetPath = $"Assets/Res/UI/Font/{fontPath}";
        string localizePath = GetLocalizationPath(assetPath);
        
        // if (!ResLoad.HasAsset(localizablePath)) return null; 
        if (m_multiFontObjectDic.TryGetValue(localizePath, out Font font)) return font;
        
        // font=(Font) ResLoad.LoadResources(localizePath);
        m_multiFontObjectDic[localizePath] = font;
        return font;
    }

    /// <summary>
    /// 加载Buildin时的翻译
    /// </summary>
    public void LoadBuildinTranslate()
    {
        
    }

    public string Translate(string text)
    {
        return text;
    }

    public bool NeedTranslate()
    {
        return CurLanguage != BaseLan;
    }

    public string GetLocalizationPath(string path)
    {
        if (string.IsNullOrEmpty(path)) return string.Empty;

        return path.Replace("Assets/Res/UI", "Assets/Res/UI/Localize" + CurLanguageFolderName);
    }
    
    ///当前语言是否为泰语
    public bool IsThaLanguage()
    {
        return CurLanguage == "tha";
    }
}