using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TextFontManager))]
public class TextFontManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // 複数のオブジェクトが選択されている場合は処理をスキップ
        if (targets.Length > 1)
        {
            EditorGUILayout.HelpBox("複数のオブジェクトを選択しているため、編集はサポートされていません。", MessageType.Warning);
            return;
        }

        TextFontManager manager = (TextFontManager)target;

        if (GUILayout.Button("適用 - すべてのフォント"))
        {
            manager.ApplyAllFonts();
        }
    }
}
