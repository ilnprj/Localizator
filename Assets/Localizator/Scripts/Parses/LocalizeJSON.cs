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
    public Dictionary<string, string> ParsedLocalization { get; set; } = new Dictionary<string, string>();
    public Dictionary<string, string> GetParsedLocalization()
    {
        return ParsedLocalization;
    }

    public void InitParseModule(string currentLanguage)
    {
        ParsedLocalization = new Dictionary<string, string>();
        TextAsset data = Resources.Load<TextAsset>(PATH);
        var allLocalizations = JSON.Parse(data.text);
        string key = " ";
        string value = " ";
        for (int i = 0; i < allLocalizations.Count; i++)
        {
            key = allLocalizations[i][0]["key"].ToString();
            if (!string.Equals(allLocalizations[i][0][currentLanguage].ToString(),"null"))
            {
                value = allLocalizations[i][0][currentLanguage].ToString();
                Debug.LogError(value);
            }
            else
            {
                //1 - is the index first default lang in JSON file
                value = allLocalizations[i][0][1].ToString();
            }
            //FIXME: For some reason JSON get string value with quotes
            key = key.Replace("\"",string.Empty);
            value = value.Replace("\"",string.Empty);
            ParsedLocalization.Add(key, value);
        }
    }
}
