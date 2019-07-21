using UnityEngine;
using System;

namespace LocalizatorSystem
{
    /// <summary>
    /// This script switch type parsing in Localizator.
    /// If this script not set in scene - Localizator set default type Parse automatically.
    /// </summary>
    public class SwitchTypeParser : MonoBehaviour
    {
        public enum TypeParser
        {
            XML, JSON
        }

        public TypeParser Parser = TypeParser.XML;
        private void Awake()
        {
            SetTypeParser();
        }

        private void SetTypeParser()
        {
            switch (Parser)
            {
                case TypeParser.JSON:
                    {
                        Localizator.CurrentTypeParse = new LocalizeJSON();
                        break;
                    }

                case TypeParser.XML:
                    {
                        Localizator.ParseableLocalize = new LocalizeXML();
                        break;
                    }
            }
            Action<bool> onInit = delegate { };
            Localizator.Init(onInit);
        }
    }

}
