using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// class which transfers only keys from the string to the localizator
/// </summary>
public class KeysTranslator
{
    private const char openKey = '[';
    private const char closeKey = ']';

    private List<int> markersOpen;
    private List<int> markersClose;

    public List<string> GetAllKeys(string text)
    {
        List<string> resultKeys = new List<string>();
        
        bool isKey = false;
        string curKey = string.Empty;

        for (int i=0;i<text.Length;i++)
        {   
            if (text[i]==openKey && !isKey)
            {
                isKey = true;
                markersOpen.Add(i);
                continue;
            }

            if (text[i]==closeKey && isKey)
            {
                isKey = false;
                resultKeys.Add(curKey);
                markersClose.Add(i);
                curKey = string.Empty;
            }

            if (isKey)
            {
                curKey+=text[i];
            }
        }
        
        foreach (var item in resultKeys)
        {
            Debug.Log("KEY = "+item);
        }

        return resultKeys;
    }

    public string GetFinalLocalize(List<string> LocalizedText)
    {
        //TODO: Доделать возврат 
        return LocalizedText[0];
    }

}