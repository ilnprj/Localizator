using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class KeysChecker
{
    private static char[] separators  = { '[', ']', '{', '}' };

    public static List<string> GetAllKeys(string text)
    {
        List<string> resultKeys = new List<string>();
        
    
        for (int i=0;i<text.Length;i++)
        {
            if (CompareSeparator(text[i]))
            {
                //TODO: Сделать разделение слов по тэгам сепаратора
            }
        }

        return resultKeys;
    }

    private static bool CompareSeparator(char c)
    {
        bool compared = false;
        for (int i=0;i<separators.Length;i++)
        {
            compared = c==separators[i];

            if (compared)
            {
                return true;
            }
        }
        return compared;
    }
}