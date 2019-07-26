/// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace LocalizatorSystem
{
    using UnityEngine;
    using System.Collections.Generic;

    /// <summary>
    /// CSV parser that takes the necessary parameters from the localization files
    /// </summary>
    public class LocalizeCSV : IParseableLocalize
    {
        public List<string> AvailableLanguages { get; set; }
        public Dictionary<string, string> ParsedLocalization { get; set; }

        private const string PATH = "LocCSV";
        private const char lineSep = '\n';
        private const char fieldSep = ';';
        public void InitParseModule(string currentLanguage)
        {
            TextAsset textFromFile = TextAssetFromFile.GetTextAsset(PATH);
            ParsedLocalization = new Dictionary<string, string>();
            AvailableLanguages = new List<string>();
            ParseCSV(textFromFile.text, currentLanguage);
        }

        private void ParseCSV(string locText, string curLang)
        {
            string[] lines = locText.Split(lineSep);
            SetAvailableLangs(lines);
            SetLocalizationDic(lines, curLang);
        }

        private void SetAvailableLangs(string[] lines)
        {
            string[] fields = lines[0].Split(fieldSep);
            int j = 0;
            foreach (var field in fields)
            {
                if (j > 0)
                {
                    AvailableLanguages.Add(field);
                }
                j++;
            }
        }

        private void SetLocalizationDic(string[] lines, string curLang)
        {
            string keyForLoc = string.Empty;
            string valueForLoc = string.Empty;
            //FIXME:
            //This section of code is very dirty and dump, but nothing else came to mind when working with CSV format.
            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(fieldSep);
                int j = 0;
                foreach (var field in fields)
                {
                    if (j == 0)
                    {
                        keyForLoc = field;
                        j++;
                        continue;
                    }

                    if (j == (AvailableLanguages.FindIndex(m => m.Equals(curLang))+1))
                    {
                        valueForLoc = field;
                    }
                    j++;
                }
                ParsedLocalization.Add(keyForLoc,valueForLoc);
            }
        }
    }
}