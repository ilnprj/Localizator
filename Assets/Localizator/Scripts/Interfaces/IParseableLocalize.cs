namespace LocalizatorSystem
{
    using System.Collections.Generic;
    /// <summary>
    /// Interface that using in Localizator class
    /// </summary>
    public interface IParseableLocalize
    {
        List<string> AvailableLanguages {get; set;}
        Dictionary<string, string> ParsedLocalization { get; set; }

        void InitParseModule(string currentLanguage);
    }
}

