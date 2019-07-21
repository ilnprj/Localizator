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
        /// <summary>
        /// In default type parse set in XML
        /// </summary>
        public static IParseableLocalize CurrentTypeParse = new LocalizeXML();
        /// <summary>
        /// Class that provides Select Lang
        /// </summary>
        /// <returns></returns>
        public static ILocale Locale = new LocaleLanguage();
        private static IParseableLocalize parseableLocalize;


        /// <summary>
        /// Initialize Localizator
        /// </summary>
        /// <param name="onInited"></param>
        public static void Init(Action<bool> onInited)
        {
            parseableLocalize = CurrentTypeParse;
            parseableLocalize.InitParseModule(Locale.GetLanguageId());
            //Get new localization keys.
            LocalizationKeys = new Dictionary<string, string>();
            LocalizationKeys = parseableLocalize.GetParsedLocalization();
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
            Locale.SetLanguage(language);
            //Send event to all GetLocalizeText components for updating localization
            LocalizeHandler.Invoke();
        }

        /// <summary>
        /// Change Language through string "Language"
        /// </summary>
        /// <param name="language"></param>
        public static void ChangeLanguage(string language)
        {
            Locale.SetLanguage(language);
            //Send event to all GetLocalizeText components for updating localization
            LocalizeHandler.Invoke();
        }
    }
}
