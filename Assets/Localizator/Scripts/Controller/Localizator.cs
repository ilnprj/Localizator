/// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

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
        public static IParseableLocalize CurrentTypeParse = new LocalizeXML();
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

        private static string TryLocalize(string key)
        {
            if (LocalizationKeys.ContainsKey(key))
            {
                return LocalizationKeys[key];
            }
            else
            {
                Debug.LogError("Key " + key + " is not found in Dictionary.");
                return string.Empty;
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
                onLocalize.Invoke(GetLocalizeText(key));
            }
            else
            {
                Init((Inited) =>
                {
                    if (Inited)
                    {
                        onLocalize.Invoke(GetLocalizeText(key));
                    }
                    else
                    {
                        Debug.LogError("Error initialize localizator");
                    }
                });
            }
        }

        private static string GetLocalizeText(string key)
        {
            KeysTranslator translator = new KeysTranslator();
            List<string> resultKeys = translator.FindKeysInText(key);
            List<string> localizeKeys = new List<string>();
            foreach (var item in resultKeys)
            {
                string result = TryLocalize(item);
                if (!string.IsNullOrEmpty(result))
                {
                    localizeKeys.Add(result);
                }
            }

           return translator.GetFinalLocalize(localizeKeys);
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
