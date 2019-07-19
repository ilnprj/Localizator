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
    private static IParseableLocalize _parseableLocalize;

    /// <summary>
    /// Initialize Localizator
    /// </summary>
    /// <param name="onInited"></param>
    public static void Init(Action<bool> onInited)
    {
        //Init parse module.
        _parseableLocalize = new LocalizeXML(GetLanguageString());
        //Get new localization keys.
        LocalizationKeys = new Dictionary<string, string>();
        LocalizationKeys = _parseableLocalize.GetParsedLocalization();
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
            Debug.LogError("Ключ " + key + " не найден в базе.");
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
                    Debug.LogError("Ошибка инициализации localizator");
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
                    PlayerPrefs.SetString("CurrentLanguage", "EN");
                    break;
                }
            case SystemLanguage.Russian:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "RU");
                    break;
                }
            case SystemLanguage.French:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "FR");
                    break;
                }
            case SystemLanguage.German:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "DE");
                    break;
                }
            case SystemLanguage.Italian:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "IT");
                    break;
                }
            case SystemLanguage.Spanish:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "ES");
                    break;
                }
            case SystemLanguage.Portuguese:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "IT");
                    break;
                }
            case SystemLanguage.Chinese:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "ZH");
                    break;
                }
            case SystemLanguage.Korean:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "KO");
                    break;
                }
            case SystemLanguage.Japanese:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "JP");
                    break;
                }
            default:
                {
                    PlayerPrefs.SetString("CurrentLanguage", "EN");
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
            switch (loadedLang)
            {
                case "EN":
                    { return SystemLanguage.English; }
                case "RU":
                    { return SystemLanguage.Russian; }
                case "FR":
                    { return SystemLanguage.French; }
                case "DE":
                    { return SystemLanguage.German; }
                case "IT":
                    { return SystemLanguage.Italian; }
                case "ES":
                    { return SystemLanguage.Spanish; }
                case "PT":
                    { return SystemLanguage.Portuguese; }
                case "ZH":
                    { return SystemLanguage.Chinese; }
                case "KO":
                    { return SystemLanguage.Korean; }
                case "JP":
                    { return SystemLanguage.Japanese; }
                default:
                    { return SystemLanguage.English; }
            }
        }

        var systemLanguage = Application.systemLanguage;
        SetLanguage(systemLanguage);
        var language = PlayerPrefs.GetString("CurrentLanguage");
        switch (language)
        {
            case "EN":
                { return SystemLanguage.English; }
            case "RU":
                { return SystemLanguage.Russian; }
            case "FR":
                { return SystemLanguage.French; }
            case "DE":
                { return SystemLanguage.German; }
            case "IT":
                { return SystemLanguage.Italian; }
            case "ES":
                { return SystemLanguage.Spanish; }
            case "PT":
                { return SystemLanguage.Portuguese; }
            case "ZH":
                { return SystemLanguage.Chinese; }
            case "KO":
                { return SystemLanguage.Korean; }
            case "JP":
                { return SystemLanguage.Japanese; }
            default:
                { return SystemLanguage.English; }
        }
    }
}
