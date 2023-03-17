using UnityEditor;
using UnityEngine;
using TextEditor = UnityEditor.UI.TextEditor;

[CustomEditor(typeof(LanguageText), true)]
[CanEditMultipleObjects]
public class LanguageTextEditor:TextEditor
{
        private SerializedProperty m_Text;
        private SerializedProperty m_FontData;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_Text = serializedObject.FindProperty("m_Text");
            m_FontData = serializedObject.FindProperty("m_FontData");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_Text);
            EditorGUILayout.PropertyField(m_FontData);
            AppearanceControlsGUI();
            RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
}

public class LanguageTextMenuEditor : Editor
{
    [MenuItem("GameObject/UI/LanguageText", false, 10)]
    private static void CreateLanguageText(MenuCommand menuCommand)
    {
        var go = new GameObject("LanguageText");
        go.AddComponent<CanvasRenderer>();
        go.AddComponent<LanguageText>();
        var parent = menuCommand.context as GameObject;
        GameObjectUtility.SetParentAndAlign(go, parent);

        //注册返回事件
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}