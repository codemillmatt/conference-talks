using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace CogTourist.Core
{
    public class EmotionService
    {
        public async Task<List<Emotion>> RecognizeEmotions(Stream image)
        {
            try
            {
                UriBuilder builder = new UriBuilder(CognitiveServiceLogin.EmotionUrl);

                image.Position = 0;

                using (var content = new StreamContent(image))
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", CognitiveServiceLogin.EmotionAPIKey);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    client.Timeout = TimeSpan.FromSeconds(20);
                    var response = await client.PostAsync(CognitiveServiceLogin.EmotionUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var rawResult = await response.Content.ReadAsStringAsync();

                        if (rawResult.Length > 2)
                            return JsonConvert.DeserializeObject<List<Emotion>>(rawResult);
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                var s = ex.ToString();
                return null;
            }
        }
    }
}

