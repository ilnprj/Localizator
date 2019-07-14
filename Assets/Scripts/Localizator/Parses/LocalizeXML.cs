using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// XML парсер, достающий из файлов локализации нужные параметры
/// </summary>
public class LocalizeXML : IParseableLocalize
{
    private const string PATH = "Localization";
    public Dictionary<string, string> ParsedXML = new Dictionary<string, string>();

    /// <summary>
    /// Constructor
    /// </summary>
    public LocalizeXML()
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
}
