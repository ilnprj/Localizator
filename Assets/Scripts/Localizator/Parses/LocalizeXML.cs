using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// XML парсер, достающий из файлов локализации нужные параметры
/// </summary>
public class LocalizeXML : IParseableLocalize
{
    private const string PATH = "Localization";
    public Dictionary<string, string> ParsedXML = new Dictionary<string, string>();

    public LocalizeXML(SystemLanguage currentLanguage)
    {
        //TODO: Тестовый режим. Всегда готово.
        ParsedXML.Add("PLAYEXAMPLE","Play 1001");
    }

    /// <summary>
    /// Возвращает готовый словарь с переведенными словами.
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> GetParsedLocalization()
    {
        return ParsedXML;
    }

    private void LoadXmlFromFile()
    {
        try
        {
            TextAsset textFromFile = Resources.Load<TextAsset>(PATH);
            ParseXml(textFromFile.text);
        }
        catch (Exception e)
        {
            Debug.Log("Failed to load XML file "+PATH+".xml Please check file!"+e.StackTrace);
        }
    }

    private void ParseXml(string inputText)
	{
	
	}
}
