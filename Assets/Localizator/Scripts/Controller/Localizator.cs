using System;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizatorSystem
{
    /// <summary>
    /// Main static class Localizator. 
    /// Saves and loads the selected language and uses third-party parsers
    /// </summary>
    public static class Localizator
    {
        public static bool Inited;
        public static SystemLanguage CurrentLanguage;
        public static Action LocalizeHandler = delegate { };
        public static Dictionary<string, string> LocalizationKeys = new Dictionary<string, string>();
        public static IParseableLocalize ParseableLocalize;

        /// <summary>
        /// In default type parse set in XML
        /// </summary>
        public static IParseableLocalize CurrentTypeParse = new LocalizeXML();


        /// <summary>
        /// Initialize Localizator
        /// </summary>
        /// <param name="onInited"></param>
        public static void Init(Action<bool> onInited)
        {
            ParseableLocalize = CurrentTypeParse;
            ParseableLocalize.InitParseModule(GetLanguageString());
            //Get new localization keys.
            LocalizationKeys = new Dictionary<string, string>();
            LocalizationKeys = ParseableLocalize.GetParsedLocalization();
            //Localizator init only if Dictionary is not empty
            onInited.Invoke(LocalizationKeys.Count > 0);
        }

        private static void TryLocalize(string key, Action<string> onLocalize)
        {
            if (LocalizationKeys.ContainsKey(key))
            {
                onLocalize.Invoke(LocalizationKeys[key]);
            }
            else
            {
                Debug.LogError("Key " + key + " is not found in Dictionary.");
            }
        }

        /// <summary>
        /// Localizing Text Components in UserInterface through Action Model
        /// </summary>
        /// <param name="key"></param>
        /// <param name="onLocalize"></param>
        public static void LocalizeText(string key, Action<string> onLocalize)
        {
            if (Inited)
            {
                TryLocalize(key, onLocalize);
            }
            else
            {
                Init((inited) =>
                {
                    if (inited)
                    {
                        TryLocalize(key, onLocalize);
                    }
                    else
                    {
                        Debug.LogError("Error initialize localizator");
                    }
                });
            }
        }

        /// <summary>
        /// Change Language through SystemLanguage 
        /// </summary>
        /// <param name="language"></param>
        public static void ChangeLanguage(SystemLanguage language)
        {
            SetLanguage(language);
            //Отправляем сигнал во все текстовые компоненты для смены перевода на новый язык
            LocalizeHandler.Invoke();
        }

        /// <summary>
        /// Change Language through string "Language"
        /// </summary>
        /// <param name="language"></param>
        public static void ChangeLanguageString(string language)
        {
            PlayerPrefs.SetString("CurrentLanguage", language);
            PlayerPrefs.Save();
            //Отправляем сигнал во все текстовые компоненты для смены перевода на новый язык
            LocalizeHandler.Invoke();
        }


        /// <summary>
        /// Set new language without auto update text components
        /// </summary>
        /// <param name="language"></param>
        public static void SetLanguage(SystemLanguage language)
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

        /// <summary>
        /// Get Current Language through Player Prefs
        /// </summary>
        /// <returns></returns>
        public static string GetLanguageString()
        {
            if (PlayerPrefs.HasKey("CurrentLanguage"))
            {
                return PlayerPrefs.GetString("CurrentLanguage");
            }

            var systemLanguage = Application.systemLanguage;
            SetLanguage(systemLanguage);
            return PlayerPrefs.GetString("CurrentLanguage");
        }

        /// <summary>
        /// Get Current Language through SystemLanguage
        /// </summary>
        /// <returns></returns>
        public static SystemLanguage GetLanguage()
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

        private static SystemLanguage GetSystemLanguage(string lang)
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
    }

}
