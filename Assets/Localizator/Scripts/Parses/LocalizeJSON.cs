/// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace LocalizatorSystem
{
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

        public List<string> AvailableLanguages {get;set;}
        public Dictionary<string, string> ParsedLocalization { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> GetParsedLocalization()
        {
            return ParsedLocalization;
        }

        public void InitParseModule(string currentLanguage)
        {
            ParsedLocalization = new Dictionary<string, string>();
            AvailableLanguages = new List<string>();
            TextAsset data = TextAssetFromFile.GetTextAsset(PATH);

            var jSON = JSON.Parse(data.text);
            var langs  = jSON["Languages"];
            var localizations = jSON["Localizations"];

            foreach (var item in langs)
            {
                string result = item.Value.ToString();
                result = deleteQuotes(result);
                AvailableLanguages.Add(result);
            }

            string key = " ";
            string value = " ";
            
            for (int i = 0; i < localizations.Count; i++)
            {
                key = localizations[i][0]["key"].ToString();
                if (!string.Equals(localizations[i][0][currentLanguage].ToString(), "null"))
                {
                    value = localizations[i][0][currentLanguage].ToString();
                }
                else
                {
                    value = localizations[i][0][1].ToString();
                }
                key = deleteQuotes(key);
                value = deleteQuotes(value);
                ParsedLocalization.Add(key, value);
            }
        }

        private string deleteQuotes(string input)
        {
            return input.Replace("\"", string.Empty);
        }
    }
}
