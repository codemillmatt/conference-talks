using System;
using System.Collections.Generic;
using Microsoft.ProjectOxford.Vision.Contract;

namespace CogTourist
{
    public class LanguageInfo
    {
        public string LanguageCode { get; set; }
        public string DisplayName { get; set; }
        public string AppleLanguageCode { get; set; }
    }

    public static class SupportedLanguages
    {
        public static List<LanguageInfo> Languages = new List<LanguageInfo> {
            new LanguageInfo { AppleLanguageCode = "fr-FR", DisplayName = "French", LanguageCode = LanguageCodes.French },
            new LanguageInfo { AppleLanguageCode = "de-DE", DisplayName = "German", LanguageCode = LanguageCodes.German },
            new LanguageInfo { AppleLanguageCode = "it-IT", DisplayName = "Italian", LanguageCode = LanguageCodes.Italian },
            new LanguageInfo { AppleLanguageCode = "ru-RU", DisplayName = "Russian", LanguageCode = LanguageCodes.Russian },
            new LanguageInfo { AppleLanguageCode = "zh-CN", DisplayName = "Chinese", LanguageCode = LanguageCodes.ChineseSimplified },
            new LanguageInfo{AppleLanguageCode="es-MX",DisplayName="Spanish", LanguageCode=LanguageCodes.Spanish}
        };
    }
}
