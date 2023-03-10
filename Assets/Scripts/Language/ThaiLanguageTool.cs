using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ThaiLanguageTool
{
    /// <summary>
    /// 默认FontSize为32
    /// </summary>
    public static int DefaultFontSize = 32; 
    /// <summary>
    /// 默认大小字体时泰文音标yOffset
    /// </summary>
    public static float YOffset = 8.0f; 
    
    private static readonly List<string> m_ignoreStr = new List<string> { "\n", " "};
    private static readonly List<int> m_foundList = new List<int>();
    public static string m_warpTag = "₵";
    private static TextGenerator m_generator;
    private static string quadStrNew = @"<quad name=(.+?) size=(\d*\.?\d+%?) width=(\d*\.?\d+%?) />";

    /// <summary>
    /// 泰文换行
    /// </summary>
    public static string ThaiWrap(string msg, Text text)
    {
        if (!LanguageManager.Instance.IsThaLanguage()) return msg.Replace(m_warpTag, "");
        
        ContentSizeFitter content = text.GetComponent<ContentSizeFitter>();
        //宽度自适应
        if ((content && content.horizontalFit == ContentSizeFitter.FitMode.PreferredSize) || text.rectTransform.rect.size.x == 0) return ReplaceWarpWord(msg);
        //高度自适应
        if ((content && content.verticalFit == ContentSizeFitter.FitMode.PreferredSize)||text.rectTransform.rect.size.y == 0)
        {
            string newStr = msg.Replace(m_warpTag, "");
            float preferredHeight = text.cachedTextGeneratorForLayout.GetPreferredWidth(newStr, text.GetGenerationSettings(Vector2.zero)) / text.pixelsPerUnit;
            return ThaiWrap(msg, text, preferredHeight);
        }

        if (!Regex.IsMatch(msg, quadStrNew)) msg = msg.Replace(" ", "\u00A0");

        if (!msg.Contains(m_warpTag)) return msg;

        var segIndexList = GetSplitList(msg);
        msg = msg.Replace(m_warpTag, "");

        text.cachedTextGenerator.PopulateWithErrors(msg, text.GetGenerationSettings(text.rectTransform.rect.size), text.gameObject);
        var lines = text.cachedTextGenerator.lines;
        if (lines.Count <= 1) return msg;

        //文本存在多行时才回去换行
        var lineIndex = 1;
        var startIndexList = new List<int>();
        int segIndex;
        string str, lastStr, nextStr;
        while (lineIndex < lines.Count)
        {
            if (lines[lineIndex].startCharIdx == 0)
            {                        
                lineIndex += 1; 
                continue;
            }
            //手动换行的不处理
            str = msg.Substring(lines[lineIndex].startCharIdx - 1, 1);
            if (str == "\n")
            {
                lineIndex += 1;
                continue;
            }
            
            //获取到每行最后一个单词结尾的index
            segIndex = GetSplitIndex(lines[lineIndex].startCharIdx, segIndexList);
            //开头或者结尾就不加换行
            if (segIndex <= 0 || segIndex >= msg.Length - 1)
            {
                lineIndex += 1;                                                                                                                                                              
                continue;
            }
            str = msg.Substring(segIndex, 1);
            lastStr = msg.Substring(segIndex - 1, 1);
            nextStr = msg.Substring(segIndex + 1, 1);
            if (m_ignoreStr.Contains(str) || m_ignoreStr.Contains(lastStr) || m_ignoreStr.Contains(nextStr))
            {
                lineIndex += 1;
                continue;
            }
            
            msg = msg.Insert(segIndex, "\n");
            
            for (int i = 0; i < segIndexList.Count; i++)
            {
                if (segIndexList[i] > segIndex)
                {
                    segIndexList[i] += 1;
                }
            }
            text.cachedTextGenerator.PopulateWithErrors(msg, text.GetGenerationSettings(text.rectTransform.rect.size), text.gameObject);
            lines = text.cachedTextGenerator.lines;
            lineIndex += 1;
        }
        return msg;
    }
    
    public static string ThaiWrap(string msg, Text text, float h)
    {
        if (!LanguageManager.Instance.IsThaLanguage()) return msg.Replace(m_warpTag, "");
        
        if (!Regex.IsMatch(msg, quadStrNew)) msg = msg.Replace(" ", "\u00A0");
        if (!msg.Contains(m_warpTag)) return msg;

        var segIndexList = GetSplitList(msg);
        msg = msg.Replace(m_warpTag, "");

        text.cachedTextGenerator.PopulateWithErrors(msg, text.GetGenerationSettings(new Vector2(text.rectTransform.rect.size.x, h)), text.gameObject);
        var lines = text.cachedTextGenerator.lines;
        if (lines.Count <= 1) return msg;

        //文本存在多行时才回去换行
        var lineIndex = 1;
        var startIndexList = new List<int>();
        int segIndex;
        string str, lastStr, nextStr;
        while (lineIndex < lines.Count)
        {
            if (lines[lineIndex].startCharIdx == 0)
            {                        
                lineIndex += 1; 
                continue;
            }
            //手动换行的不处理
            str = msg.Substring(lines[lineIndex].startCharIdx - 1, 1);
            if (str == "\n")
            {
                lineIndex += 1;
                continue;
            }
            
            //获取到每行最后一个单词结尾的index
            segIndex = GetSplitIndex(lines[lineIndex].startCharIdx, segIndexList);
            //开头或者结尾就不加换行
            if (segIndex <= 0 || segIndex >= msg.Length - 1)
            {
                lineIndex += 1;                                                                                                                                                              
                continue;
            }
            str = msg.Substring(segIndex, 1);
            lastStr = msg.Substring(segIndex - 1, 1);
            nextStr = msg.Substring(segIndex + 1, 1);
            if (m_ignoreStr.Contains(str) || m_ignoreStr.Contains(lastStr) || m_ignoreStr.Contains(nextStr))
            {
                lineIndex += 1;
                continue;
            }
            
            msg = msg.Insert(segIndex, "\n");
            
            for (int i = 0; i < segIndexList.Count; i++)
            {
                if (segIndexList[i] > segIndex)
                {
                    segIndexList[i] += 1;
                }
            }
            text.cachedTextGenerator.PopulateWithErrors(msg, text.GetGenerationSettings(new Vector2(text.rectTransform.rect.size.x, h)), text.gameObject);
            lines = text.cachedTextGenerator.lines;
            lineIndex += 1;
        }
        return msg;
    }
    
    public static string ReplaceWarpWord(string msg)
    {
        if (!LanguageManager.Instance.IsThaLanguage()) return msg;
        
        if (!msg.Contains(m_warpTag)) return msg;
        msg = msg.Replace(m_warpTag, "");

        return msg;
    }

    public static int GetSplitIndex(int startIndex, List<int> segIndex)
    {
        for (int i = 1; i <= segIndex.Count - 1; i++)
        {
            if (segIndex[i] > startIndex)
                return segIndex[i - 1];
        }
        
        return segIndex[segIndex.Count - 1];
    }

    /// <summary>
    /// 获取每行换行最后字符索引的位置
    /// </summary>
    public static List<int> GetSplitList(string text)
    {
        int foundPos;
        var startIndex = 0;
        var count = 0;
        m_foundList.Clear();
        do
        {
            foundPos = text.IndexOf(m_warpTag, startIndex, StringComparison.Ordinal);
            if (foundPos <= -1) continue;
            startIndex = foundPos + 1;
            if (!m_foundList.Contains(foundPos)) //去掉分隔符一行最后字符索引
                m_foundList.Add(foundPos - count);
            else
            {
                DebugL8.LogError($"foundPos 重复 查找分隔符失败  text：{text}");
                break;
            }

            count++;
        } while (foundPos > -1 && startIndex < text.Length);
        return m_foundList;
    }
    
    /// <summary>
    /// 替换掉Text中不渲染的字符（富文本/空格/转义/超链接）
    /// </summary>
    public static string ReplaceRichText(Text text)
    {
        var msg = text.text;
        if (!LanguageManager.Instance.IsThaLanguage()) return msg;
        
        //unity2018中文本超框富文本等有渲染数据
        if (IsOutText(text)) return msg;

        msg = msg.Replace(" ", "");
        msg = msg.Replace("\n", "");
        msg = Regex.Replace(msg, @"<color=[#0-9a-zA-Z]+>|</color>", "");
        msg = Regex.Replace(msg, @"(<color=(.+)>|</color>)", "");
        msg = Regex.Replace(msg, @"(<link(.+)>)", "");

        return msg;
    }

    /// <summary>
    /// Text是否超框
    /// </summary>
    public static bool IsOutText(Text text)
    {
        var value = text.text;
        if(m_generator==null)
            m_generator = new TextGenerator();
        var rectTransform = text.GetComponent<RectTransform>();
        var settings = text.GetGenerationSettings(rectTransform.rect.size);
        m_generator.Populate(value, settings);
        var characterCountVisible = m_generator.characterCountVisible;
        return value.Length > characterCountVisible;
    }
}
