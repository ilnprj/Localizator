using System.Collections.Generic;

/// <summary>
/// Interface that using in Localizator class
/// </summary>
public interface IParseableLocalize
{
    Dictionary<string,string> ParsedLocalization { get; set;}
    Dictionary<string,string>GetParsedLocalization();
}
