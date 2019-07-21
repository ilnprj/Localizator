using UnityEngine;
using UnityEngine.UI;

namespace LocalizatorSystem
{
    /// <summary>
    /// Component for text. Send key to Localizator and get localized value.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class GetLocalizeText : MonoBehaviour
    {
        private Text textComponent;
        private string keyForLocalize;
        private void Awake()
        {
            textComponent = GetComponent<Text>();
            keyForLocalize = textComponent.text;
        }

        private void OnEnable()
        {
            Localizator.LocalizeHandler += OnLocalizeHandler;
            OnLocalizeHandler();
        }

        private void OnDisable()
        {
            Localizator.LocalizeHandler -= OnLocalizeHandler;
        }

        private void OnLocalizeHandler()
        {
            Localizator.LocalizeText(keyForLocalize, delegate (string s) { textComponent.text = s; });
        }
    }

}
