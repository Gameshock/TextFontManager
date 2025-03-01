using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable]
public class FontGroup
{
    [Header("適用するフォント")]
    public TMP_FontAsset fontAsset;

    [Header("このフォントを適用するテキストリスト")]
    public List<TextMeshProUGUI> textElements = new List<TextMeshProUGUI>();
}

public class TextFontManager : MonoBehaviour
{
    [Header("フォントごとの適用テキスト管理")]
    public List<FontGroup> fontGroups = new List<FontGroup>();

    /// <summary>
    /// すべてのフォントグループを適用（インスペクターから実行可能）
    /// </summary>
    [ContextMenu("適用 - すべてのフォント")]
    public void ApplyAllFonts()
    {
        foreach (var fontGroup in fontGroups)
        {
            ApplyFont(fontGroup.fontAsset);
        }
    }

    /// <summary>
    /// 指定したフォントを適用（フォントに関連するテキスト要素のみ）
    /// </summary>
    public void ApplyFont(TMP_FontAsset font)
    {
        if (font == null)
        {
            Debug.LogWarning("適用するフォントが設定されていません！");
            return;
        }

        // フォントに対応するテキストリストを探して適用
        foreach (var fontGroup in fontGroups)
        {
            if (fontGroup.fontAsset == font)
            {
                foreach (var textElement in fontGroup.textElements)
                {
                    if (textElement != null)
                    {
                        textElement.font = font;
                    }
                }
                Debug.Log($"フォント適用完了: {font.name}");
                return;
            }
        }

        Debug.LogWarning($"フォント {font.name} に対応するテキストが見つかりません！");
    }
}
