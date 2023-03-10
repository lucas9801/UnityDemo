using System;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : Text
{
    protected string m_lanText;
    protected bool m_translated;
    protected bool m_needAutoSetMultiFont = true;
    private static readonly UIVertex[] m_TempVerts = new UIVertex[4];

    protected override void Awake()
    {
        MultiLanguageFontReplace();
    }

    /// <summary>
    /// 多语言Font替换
    /// </summary>
    private void MultiLanguageFontReplace()
    {
        if (!m_needAutoSetMultiFont) return;
        if (font == null)
        {
            DebugL8.LogError("Font文件为空");
            return;
        }

        Font newFont = LanguageManager.Instance.MultilnaguageFontReplace(font.name);
        if (newFont == null) return;

        font = newFont;
        Transform parent = gameObject.transform.parent;
        bool needAutoEnable = parent == null || parent.GetComponent<InputField>() == null;
        if (needAutoEnable) enabled = true;
    }

    public override string text
    {
        get
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return base.text;
#endif
            if (!m_translated) ToTranslate();
            return m_lanText;
        }
        set
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                base.text = value;
                return;
            }
#endif
            if (string.IsNullOrEmpty(value))
            {
                m_lanText = "";
                m_translated = true;
                SetVerticesDirty();
            }
            else
            {
                if (m_lanText == value) return;
                if (!m_translated) ToTranslate();
                SetVerticesDirty();
                SetLayoutDirty();
            }
        }
    }

    public override float flexibleWidth
    {
        get
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return base.preferredWidth;
#endif
            if (!m_translated) ToTranslate();
            return this.cachedTextGeneratorForLayout.GetPreferredWidth(m_lanText, GetGenerationSettings(Vector2.zero)) /
                   this.pixelsPerUnit;
        }
    }

    public override float flexibleHeight
    {
        get
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return base.preferredHeight;
#endif
            if (!m_translated) ToTranslate();
            return this.cachedTextGeneratorForLayout.GetPreferredHeight(this.m_lanText, this.GetGenerationSettings(new Vector2(this.GetPixelAdjustedRect().size.x, 0.0f))) / this.pixelsPerUnit;
        }
    }

    private void ToTranslate()
    {
        string txt = LanguageManager.Instance.Translate(m_Text);
        // m_lanText = ThaiLanguageTool.ThaiWrap(txt, this);
        m_translated = true;
    }

    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        if (font == null) return;
        m_DisableFontTextureRebuiltCallback = true;
        cachedTextGenerator.PopulateWithErrors(text, GetGenerationSettings(rectTransform.rect.size), gameObject);
        var verts = cachedTextGenerator.verts;
        var num = 1f / pixelsPerUnit;
        var count = verts.Count;
        if (count <= 0) toFill.Clear();
        else
        {
                var point = new Vector2(verts[0].position.x, verts[0].position.y) * num;
            var vector2 = PixelAdjustPoint(point) - point;
            toFill.Clear();
            var posUpY = ThaiLanguageTool.YOffset * fontSize / ThaiLanguageTool.DefaultFontSize;
            var richText = ThaiLanguageTool.ReplaceRichText(this);
            if (vector2 != Vector2.zero)
            {
                for (var index1 = 0; index1 < count; ++index1)
                {
                    var index2 = index1 & 3;
                    m_TempVerts[index2] = verts[index1];
                    m_TempVerts[index2].position *= num;
                    m_TempVerts[index2].position.x += vector2.x;
                    m_TempVerts[index2].position.y += vector2.y;
                    if (LanguageManager.Instance.IsThaLanguage())
                    {
                        var index = index1 / 4;
                        if (index < richText.Length)
                        {
                            var sub = richText.ToCharArray(index, 1)[0];
                            if (Convert.ToInt32(sub) >= 3656 && Convert.ToInt32(sub) <= 3659)//泰文的四个音标特殊处理一下yOffset
                                m_TempVerts[index2].position.y += posUpY;
                        }
                    }
                    if (index2 == 3)
                        toFill.AddUIVertexQuad(m_TempVerts);
                }
            }
            else
            {
                for (var index3 = 0; index3 < count; ++index3)
                {
                    var index4 = index3 & 3;
                    m_TempVerts[index4] = verts[index3];
                    m_TempVerts[index4].position *= num;
                    if (LanguageManager.Instance.IsThaLanguage())
                    {
                        var index = index3 / 4;
                        if (index < richText.Length)
                        {
                            var sub = richText.ToCharArray(index, 1)[0];
                            if (Convert.ToInt32(sub) >= 3656 && Convert.ToInt32(sub) <= 3659)//泰文的四个音标特殊处理一下yOffset
                                m_TempVerts[index4].position.y += posUpY;
                        }
                    }
                    if (index4 == 3)
                        toFill.AddUIVertexQuad(m_TempVerts);
                }
            }
            m_DisableFontTextureRebuiltCallback = false;
        }
    }
}
