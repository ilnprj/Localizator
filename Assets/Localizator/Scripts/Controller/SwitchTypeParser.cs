using UnityEngine;

/// <summary>
/// This script switch type parsing in Localizator.
/// If this script not set in scene - Localizator set default type Parse automatically.
/// WARNING. This script must be activated before first call component "GetLocalizeText". For example in scene "Loading"
/// </summary>
public class SwitchTypeParser : MonoBehaviour
{
    public enum TypeParser
    {
        XML, JSON
    }

    public TypeParser Parser = TypeParser.XML;
    private void Awake()
    {
        SetTypeParser();
    }

    private void SetTypeParser()
    {
        switch (Parser)
        {
            case TypeParser.JSON:
                {
                    Localizator.ParseableLocalize = new LocalizeJSON(Localizator.GetLanguageString());
                    break;
                }

            case TypeParser.XML:
                {
                    Localizator.ParseableLocalize = new LocalizeXML(Localizator.GetLanguageString());
                    break;
                }
        }
        Localizator.InitedParseType=true;
    }
}
