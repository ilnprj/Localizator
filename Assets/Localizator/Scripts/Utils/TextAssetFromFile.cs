using UnityEngine;
using System;

/// <summary>
/// Class that returns successfully loaded file from Resources or get message with error
/// </summary>
public static class TextAssetFromFile
{
    public static TextAsset GetTextAsset(string path)
    {
        TextAsset _result;
        try
        {
            _result = Resources.Load<TextAsset>(path);
            return _result;
        }
        catch (Exception e)
        {
            Debug.LogError("File " + path + ".json is not found in folder Resources!\n"+e.Message);
            return null;
        }
    }
}
