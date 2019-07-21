namespace LocalizatorSystem
{
    using UnityEngine;
    public interface ILocale
    {
        void SetLanguage(SystemLanguage language);

        void SetLanguage(string languageId);

        SystemLanguage GetLanguage();

        string GetLanguageId();
    }
}

