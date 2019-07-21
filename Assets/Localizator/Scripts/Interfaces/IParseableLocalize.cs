﻿using System.Collections.Generic;

/// <summary>
/// Interface that using in Localizator class
/// </summary>
public interface IParseableLocalize
{
    Dictionary<string,string> ParsedLocalization { get; set;}

    void InitParseModule(string currentLanguage);

    Dictionary<string,string>GetParsedLocalization();
}