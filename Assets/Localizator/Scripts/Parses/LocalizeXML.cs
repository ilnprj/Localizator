namespace LocalizatorSystem
{
    using System.Xml;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using System.IO;

    /// <summary>
    /// XML parser that takes the necessary parameters from the localization files
    /// </summary>
    public class LocalizeXML : IParseableLocalize
    {
        private const string PATH = "LocXML";
        public Dictionary<string, string> ParsedLocalization { get; set; }
        public List<string> AvailableLanguages { get; set; }

        public void InitParseModule(string currentLanguage)
        {
            LoadXmlFromFile(currentLanguage);
        }

        /// <summary>
        /// Returns Dictionary with key/value of localization from XML file
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetParsedLocalization()
        {
            return ParsedLocalization;
        }

        private void LoadXmlFromFile(string lang)
        {
            try
            {
                ParsedLocalization = new Dictionary<string, string>();
                TextAsset textFromFile = Resources.Load<TextAsset>(PATH);
                ParseXml(textFromFile.text, lang);
            }
            catch (Exception e)
            {
                Debug.Log("Failed to load XML file " + PATH + ".xml Please check file!" + e.StackTrace);
            }
        }

        private void ParseXml(string inputText, string lang)
        {
            string keyLocalize;
            string valueLocalized = " ";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(inputText));
            XmlNodeList listTexts = xmlDoc.GetElementsByTagName("Line");
            XmlNodeList languages = xmlDoc.GetElementsByTagName("Languages");
            try
            {
                foreach (XmlNode item in listTexts)
                {
                    //Add Key for Localize
                    keyLocalize = item.Attributes[0].InnerText;
                    string guaranteedValue = item.ChildNodes[0].InnerText;
                    string prevLocValue = valueLocalized;

                    foreach (XmlNode subItem in item.ChildNodes)
                    {
                        if (subItem.LocalName == lang)
                        {
                            //Add Value current Key for Localize
                            valueLocalized = subItem.InnerText;
                        }
                    }

                    if (valueLocalized != prevLocValue)
                    {
                        ParsedLocalization.Add(keyLocalize, valueLocalized);
                    }
                    else
                    {
                        ParsedLocalization.Add(keyLocalize, guaranteedValue);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Incorrect format XML Localization. Maybe missing key or value.");
                Debug.LogError(e.Message);
            }
        }
    }

}
