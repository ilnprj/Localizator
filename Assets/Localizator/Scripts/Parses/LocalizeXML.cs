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
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(inputText));
            SetAvailableLangs(xmlDoc);
            SetLocalization(xmlDoc, lang);
        }

        private void SetAvailableLangs(XmlDocument xml)
        {
            try
            {
                XmlNodeList languages = xml.GetElementsByTagName("Languages");
                AvailableLanguages = new List<string>();
                foreach (XmlNode nodeItem in languages)
                {
                    foreach (XmlNode item in nodeItem)
                    {
                        AvailableLanguages.Add(item.InnerText);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error get available languages. Check XML file!\n"+e.Message);
            }
        }

        private void SetLocalization(XmlDocument xml, string lang)
        {
            XmlNodeList listTexts = xml.GetElementsByTagName("Line");
            string keyLocalize;
            string valueLocalized = " ";
            try
            {
                foreach (XmlNode item in listTexts)
                {
                    keyLocalize = item.Attributes[0].InnerText;
                    string guaranteedValue = item.ChildNodes[0].InnerText;
                    string prevLocValue = valueLocalized;

                    foreach (XmlNode subItem in item.ChildNodes)
                    {
                        if (subItem.LocalName == lang)
                        {
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
                Debug.LogError("Incorrect format XML Localization. Maybe missing key or value."+e.Message);
            }
        }
    }
}
