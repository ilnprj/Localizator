namespace LocalizatorSystem
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

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
        public static List<string> AvailableLanguages = new List<string>();
        public static IParseableLocalize CurrentTypeParse = new LocalizeJSON();
        public static ILocale Locale = new LocaleLanguage();
        private static IParseableLocalize parseableLocalize;
        
        public static void Init(Action<bool> onInited)
        {
            parseableLocalize = CurrentTypeParse;
            parseableLocalize.InitParseModule(Locale.GetLanguageId());
            try
            {
                LocalizationKeys = new Dictionary<string, string>();
                LocalizationKeys = parseableLocalize.ParsedLocalization;
                AvailableLanguages = new List<string>();
                AvailableLanguages = parseableLocalize.AvailableLanguages;
                onInited.Invoke(Inited = true);
            }
            catch
            {
                onInited.Invoke(Inited = false);
                Debug.LogError("Failed Init Localizator");
            }
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
                Init((Inited) =>
                {
                    if (Inited)
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
        /// Change Language through string "Language"
        /// </summary>
        /// <param name="language"></param>
        public static void ChangeLanguage(string language)
        {
            Inited = false;
            Locale.SetLanguage(language);
            LocalizeHandler.Invoke();
        }
    }
}
