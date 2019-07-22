namespace LocalizatorSystem
{
    using UnityEngine;
    using System.Collections.Generic;

    
    /// <summary>
    /// CSV parser that takes the necessary parameters from the localization files
    /// </summary>
    public class LocalizeCSV : IParseableLocalize
    {
        public List<string> AvailableLanguages {get; set;}
        public Dictionary<string, string> ParsedLocalization { get; set; }

        private const string PATH = "LocCSV";
        public void InitParseModule(string currentLanguage)
        {
            TextAsset textFromFile = TextAssetFromFile.GetTextAsset(PATH);
            ParseCSV(textFromFile.text);
        }

        private void ParseCSV(string locText)
        {

        }
    }
}