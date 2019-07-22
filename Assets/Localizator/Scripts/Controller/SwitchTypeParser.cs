namespace LocalizatorSystem
{
    using UnityEngine;
    using System;

    /// <summary>
    /// This script switch type parsing in Localizator.
    /// If this script not set in scene - Localizator set default type Parse automatically.
    /// </summary>
    public class SwitchTypeParser : MonoBehaviour
    {
        public enum TypeParser
        {
            XML, JSON, CSV
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
                        Localizator.CurrentTypeParse = new LocalizeXML();
                        break;
                    }
                case TypeParser.CSV:
                    {
                        Localizator.CurrentTypeParse = new LocalizeCSV();
                        break;
                    }
            }
            Action<bool> onInit = delegate { };
            Localizator.Init(onInit);
        }
    }

}
