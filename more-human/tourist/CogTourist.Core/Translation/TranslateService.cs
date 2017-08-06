using System;
using System.Resources;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace CogTourist.Core
{
    public class TranslateService
    {
        static readonly TimeSpan tokenDuration = TimeSpan.FromMinutes(8);
        static readonly string subscriptionKeyHeader = "Ocp-Apim-Subscription-Key";

        AuthenticationHeaderValue bearerToken = null;
        DateTimeOffset tokenExpiration = DateTimeOffset.Now;

        public TranslateService()
        {
        }

        public async Task<AuthenticationHeaderValue> GetAuthorizationToken()
        {
            if (tokenExpiration > DateTimeOffset.Now && bearerToken != null)
                return bearerToken;

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(CognitiveServiceLogin.TranslateTokenUrl);
                request.Content = new StringContent("");
                request.Headers.TryAddWithoutValidation(subscriptionKeyHeader, CognitiveServiceLogin.TranslateAPIKey);

                client.Timeout = TimeSpan.FromSeconds(20);

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                bearerToken = new AuthenticationHeaderValue("Bearer", content);
                tokenExpiration = DateTimeOffset.Now + tokenDuration;

                return bearerToken;
            }

        }

        public async Task<string> TranslateText(string text, string fromLanguage, string toLanguage)
        {
            var textKvp = new KeyValuePair<string, string>("text", text);
            var fromKvp = new KeyValuePair<string, string>("from", fromLanguage);
            var toKvp = new KeyValuePair<string, string>("to", toLanguage);

            using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[] { textKvp, fromKvp, toKvp }))
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                try
                {
                    var builder = new UriBuilder(CognitiveServiceLogin.TranslateUrl);
                    builder.Query = await content.ReadAsStringAsync();

                    request.Method = HttpMethod.Get;
                    request.RequestUri = builder.Uri;
                    var token = await GetAuthorizationToken();
                    request.Headers.Authorization = token;// await GetAuthorizationToken();

                    client.Timeout = TimeSpan.FromSeconds(60);

                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();

                    return XElement.Parse(result).Value;
                }
                catch (Exception ex)
                {
                    return "";
                }

            }
        }
    }
}
