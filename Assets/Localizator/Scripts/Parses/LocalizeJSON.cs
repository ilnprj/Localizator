using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

/// <summary>
/// JSON parser that takes the necessary parameters from the localization files
/// </summary>
public class LocalizeJSON : IParseableLocalize
{
    public const string PATH = "LocJSON";
    public Dictionary<string, string> ParsedLocalization { get; set; }
    public Dictionary<string, string> GetParsedLocalization()
    {
        return ParsedLocalization;
    }

    public LocalizeJSON(string currentLanguage)
    {
        TextAsset data = Resources.Load<TextAsset>(PATH);
        var allLocalizations = JSON.Parse(data.text);
        string key = " ";
        string value = " ";
        for (int i = 0; i < allLocalizations.Count; i++)
        {
            key = allLocalizations[i][0]["key"].ToString();
            try
            {
                value = allLocalizations[i][0][currentLanguage].ToString();
            }
            catch(Exception e)
            {
                Debug.LogError(e.Message);
                value = allLocalizations[i][0][0].ToString();
            }
            ParsedLocalization.Add(key, value);
        }
    }
}
