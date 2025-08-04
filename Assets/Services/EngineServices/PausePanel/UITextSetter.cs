using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UITextSetter : MonoBehaviour
{
    private LocString text;
    private TMP_Text _tmp;

    public void Init(LocString s)
    {
        text = s;
        _tmp = GetComponent<TMP_Text>();
        UpdateUI();
    }
    public void UpdateUI()
    {
        _tmp.SetText(text.ToString());
        RectTransform rectTransform = GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        
    }
}
