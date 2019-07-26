/// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace LocalizatorSystem
{
    using UnityEngine;
    public interface ILocale
    {
        void SetLanguage(SystemLanguage language);

        void SetLanguage(string languageId);

        SystemLanguage GetLanguage();

        string GetLanguageId();
    }
}

