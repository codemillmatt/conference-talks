namespace CogTourist.Core
{
    public static class CognitiveServiceLogin
    {
        // Get the various API keys from the Azure portal
        public static readonly string VisionAPIKey = "";
        public static readonly string TranslateAPIKey = "";
        public static readonly string EmotionAPIKey = "";
        public static readonly string VisionUrl = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0";
        public static readonly string TranslateTokenUrl = "https://api.cognitive.microsoft.com/sts/v1.0/issueToken";
        public static readonly string TranslateUrl = "https://api.microsofttranslator.com/V2/Http.svc/Translate";
        public static readonly string EmotionUrl = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize";
    }
}