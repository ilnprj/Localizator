using System;
using System.Collections.Generic;
using UnityEngine;

public static class Localizator
{
    public static bool Inited;
    public static SystemLanguage CurrentLanguage;
    public static Action LocalizeHandler = delegate { };

    public static Dictionary<string, string> LocalizationKeys = new Dictionary<string, string>();
    private static IParseableLocalize _parseableLocalize;

    public static void Init(Action<bool> onInited)
    {
        _parseableLocalize = new LocalizeXML(onInited);
		LocalizationKeys = _parseableLocalize.GetParsedLocalization();
    }

    private static void LocalizeItem(string key, Action<string> onLocalize)
    {
        if (LocalizationKeys.ContainsKey(key))
        {
            onLocalize.Invoke(LocalizationKeys[key]);
        }
		else
		{
			Debug.LogError("Ключ "+key+" не найден в базе.");
		}
    }

    public static void LocalizeText(string key, Action<string> onLocalize)
    {
        if (Inited)
        {
            LocalizeItem(key,onLocalize);
        }
        else
        {
            Init((inited) =>
            {
                if (inited)
                {
                    LocalizeText(key,onLocalize);
                }
                else
                {
                    Debug.LogError("Ошибка инициализации localizator");
                }
            });
        }
    }
    
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
    }

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
        var language = PlayerPrefs.GetString("CurLang");
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
