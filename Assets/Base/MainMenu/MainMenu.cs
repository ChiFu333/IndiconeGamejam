using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private List<UIButtonScaling> buttons;
    private List<LocString> buttonsText = new List<LocString>()
    {
        new LocString("Play", "Играть"),
        new LocString("Settings", "Настроечки"),
        new LocString("Author", "Разработичк"),
        new LocString("Exit", "Выход"),
    };

private void Awake()
    {
        Init();
    }

    private void Init()
    {
        buttons = FindObjectsByType<UIButtonScaling>(FindObjectsSortMode.None)
        .Where(obj => obj.transform.parent.GetComponent<VerticalLayoutGroup>() != null)
        .OrderBy(b => b.transform.GetSiblingIndex())
        .ToList();

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].transform.GetChild(0).gameObject.AddComponent<UITextSetter>().Init(buttonsText[i]);
        }
    }
    
}
