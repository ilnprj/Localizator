using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// JSON parser that takes the necessary parameters from the localization files
/// </summary>
public class LocalizeJSON : IParseableLocalize
{
    public Dictionary<string, string> ParsedLocalization { get; set; }
    public Dictionary<string, string> GetParsedLocalization()
    {
        return ParsedLocalization;
    }

    public LocalizeJSON(string currentLanguage)
    {

    }
}
