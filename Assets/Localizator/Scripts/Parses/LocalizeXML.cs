using System.Xml;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// XML парсер, достающий из файлов локализации нужные параметры
/// </summary>
public class LocalizeXML : IParseableLocalize
{
    private const string PATH = "Localization";
    public Dictionary<string, string> ParsedXML = new Dictionary<string, string>();

    public LocalizeXML(string currentLanguage)
    {
        LoadXmlFromFile(currentLanguage);
    }

    /// <summary>
    /// Возвращает готовый словарь с переведенными словами.
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> GetParsedLocalization()
    {
        return ParsedXML;
    }

    private void LoadXmlFromFile(string lang)
    {
        try
        {
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
        XmlNodeList ListTexts = xmlDoc.GetElementsByTagName("Line");

        try
        {
            foreach (XmlNode item in ListTexts)
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
                    ParsedXML.Add(keyLocalize, valueLocalized);
                }
                else
                {
                    ParsedXML.Add(keyLocalize, guaranteedValue);
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
