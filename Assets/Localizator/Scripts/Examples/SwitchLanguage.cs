using UnityEngine;
using UnityEngine.UI;
using LocalizatorSystem;
using System.Collections.Generic;

/// <summary>
/// Swtich Language in Runtime with UI.Dropdown
/// This is example script and does not cover a variety of test cases.
/// </summary>
public class SwitchLanguage : MonoBehaviour
{
    private Dropdown _dropDownElement;
    private List<string> languages = new List<string>();
    private void Start()
    {
        _dropDownElement = GetComponent<Dropdown>();
        _dropDownElement.onValueChanged.AddListener( delegate {
            SetNewLanguage(_dropDownElement);
        });

        LoadAvailableLangs();
        SetCurLangInDrop();
    }

    private void LoadAvailableLangs()
    {
        languages = Localizator.AvailableLanguages;
        _dropDownElement.AddOptions(languages);
 
    }

    private void SetNewLanguage(Dropdown changed)
    {
        Localizator.ChangeLanguage(changed.options[changed.value].text);
    }

    private void SetCurLangInDrop()
    {
        _dropDownElement.SetValueWithoutNotify(GetNumCurrentLang());
    }

    private int GetNumCurrentLang()
    {
        string lang = Localizator.Locale.GetLanguageId();
        return languages.FindIndex(value => value==lang);
    }

}
