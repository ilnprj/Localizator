using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// class which transfers only keys from the string to the localizator
/// </summary>
public class KeysTranslator
{
    private const char openKey = '[';
    private const char closeKey = ']';

    private string sourceText;
    List<string> resultKeys = new List<string>();

    /// <summary>
    /// Find keys in all text
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public List<string> FindKeysInText(string text)
    {
        sourceText = text;
        bool isKey = false;
        string curKey = string.Empty;

        for (int i = 0; i < sourceText.Length; i++)
        {
            if (text[i] == openKey && !isKey)
            {
                isKey = true;
                continue;
            }

            if (text[i] == closeKey && isKey)
            {
                isKey = false;
                resultKeys.Add(curKey);
                curKey = string.Empty;
            }

            if (isKey)
            {
                curKey += text[i];
            }
        }
        return resultKeys;
    }


    /// <summary>
    /// Get Final Localization with any non-localize text and symbols
    /// </summary>
    /// <param name="LocalizedText"></param>
    /// <returns></returns>
    public string GetFinalLocalize(List<string> LocalizedText)
    {
        string resultText = sourceText;
        resultText = resultText.Replace(openKey.ToString(), "");
        resultText = resultText.Replace(closeKey.ToString(), "");

        int index = 0;
        if (resultKeys.Count == LocalizedText.Count)
        {
            foreach (var item in resultKeys)
            {
                resultText = resultText.Replace(item, LocalizedText[index]);
                index++;
            }
        }
        else
        {
            Debug.LogError("String for localize and localized string is not equal! Check file localizator!");
        }
        return resultText;
    }
}