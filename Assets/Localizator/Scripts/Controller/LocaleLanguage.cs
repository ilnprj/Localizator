/// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace LocalizatorSystem
{
    using UnityEngine;
    /// <summary>
    /// The ILocale interface implementation responsible for reading and writing the current language type
    /// </summary>
    public class LocaleLanguage : ILocale
    {
        public SystemLanguage GetLanguage()
        {
            if (PlayerPrefs.HasKey("CurrentLanguage"))
            {
                var loadedLang = PlayerPrefs.GetString("CurrentLanguage");
                return GetSystemLanguage(loadedLang);
            }

            var systemLanguage = Application.systemLanguage;
            SetLanguage(systemLanguage);
            var language = PlayerPrefs.GetString("CurrentLanguage");
            return GetSystemLanguage(language);
        }

        public SystemLanguage GetSystemLanguage(string lang)
        {
            switch (lang)
            {
                case "en":
                    { return SystemLanguage.English; }
                case "ru":
                    { return SystemLanguage.Russian; }
                case "fr":
                    { return SystemLanguage.French; }
                case "de":
                    { return SystemLanguage.German; }
                case "it":
                    { return SystemLanguage.Italian; }
                case "es":
                    { return SystemLanguage.Spanish; }
                case "pt":
                    { return SystemLanguage.Portuguese; }
                case "ch":
                    { return SystemLanguage.Chinese; }
                case "ko":
                    { return SystemLanguage.Korean; }
                case "jp":
                    { return SystemLanguage.Japanese; }
                default:
                    { return SystemLanguage.English; }
            }
        }
        public string GetLanguageId()
        {
            if (PlayerPrefs.HasKey("CurrentLanguage"))
            {
                return PlayerPrefs.GetString("CurrentLanguage");
            }

            var systemLanguage = Application.systemLanguage;
            SetLanguage(systemLanguage);
            return PlayerPrefs.GetString("CurrentLanguage");
        }

        public void SetLanguage(SystemLanguage language)
        {
            switch (language)
            {
                case SystemLanguage.English:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "en");
                        break;
                    }
                case SystemLanguage.Russian:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "ru");
                        break;
                    }
                case SystemLanguage.French:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "fr");
                        break;
                    }
                case SystemLanguage.German:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "de");
                        break;
                    }
                case SystemLanguage.Italian:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "it");
                        break;
                    }
                case SystemLanguage.Spanish:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "es");
                        break;
                    }
                case SystemLanguage.Portuguese:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "pt");
                        break;
                    }
                case SystemLanguage.Chinese:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "ch");
                        break;
                    }
                case SystemLanguage.Korean:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "ko");
                        break;
                    }
                case SystemLanguage.Japanese:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "jp");
                        break;
                    }
                default:
                    {
                        PlayerPrefs.SetString("CurrentLanguage", "en");
                        break;
                    }
            }
            PlayerPrefs.Save();
        }

        public void SetLanguage(string languageId)
        {
            //TODO: There is a check of the identity of the identifier in the localizer languages
           PlayerPrefs.SetString("CurrentLanguage",languageId);
           PlayerPrefs.Save();
        }
    }
}
