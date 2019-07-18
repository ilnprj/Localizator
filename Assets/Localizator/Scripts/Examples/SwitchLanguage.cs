using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Swtich Language in Runtime with UI.Dropdown
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
    }

    private void SetNewLanguage(Dropdown changed)
    {
        Localizator.ChangeLanguageString(changed.options[changed.value].text);
    }
}
