using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Swtich Language in Runtime with UI.Dropdown
/// This is example script and does not cover a variety of test cases.
/// </summary>
public class SwitchLanguage : MonoBehaviour
{
    private Dropdown _dropDownElement;

    private void Awake()
    {
        _dropDownElement = GetComponent<Dropdown>();
        _dropDownElement.onValueChanged.AddListener( delegate {
            SetNewLanguage(_dropDownElement);
        });

        SetLangInDrop();
    }

    private void SetNewLanguage(Dropdown changed)
    {
        Localizator.ChangeLanguageString(changed.options[changed.value].text);
    }

    private void SetLangInDrop()
    {
        _dropDownElement.SetValueWithoutNotify(CurLangAdapter());
    }

    private int CurLangAdapter()
    {
        string lang = Localizator.GetLanguageString();

        switch (lang)
        {
            case "en": return 0;
            case "ru": return 1;
            case "fr": return 2;
            case "de": return 3;
            case "it": return 4;
            case "es": return 5;
            case "jp": return 6;
            case "ch": return 7;
            case "ko": return 8;
            default: return 0;
        }
    }
}
