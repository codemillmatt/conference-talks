using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using System.IO;
using System.Text;
using System.Linq;
using System;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading;

namespace CogTourist.Core
{
    public class VisionService
    {
        static readonly string could_not_analyze = "Couldn't analyze";
        static readonly string landmark_model = "landmarks";
        static readonly string celebrity_model = "celebrities";

        readonly VisionServiceClient client;

        public VisionService()
        {
            client = new VisionServiceClient(CognitiveServiceLogin.VisionAPIKey, CognitiveServiceLogin.VisionUrl);
        }

        public async Task<AnalysisResult> AnalyzePhoto(Stream photo)
        {
            try
            {
                photo.Position = 0;

                var results = await client.AnalyzeImageAsync(photo,
                    new List<VisualFeature>
                    {
                        VisualFeature.Categories,VisualFeature.Description,VisualFeature.Faces, VisualFeature.Tags, VisualFeature.Color,
                    }, null);

                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AllLandmarks> DescribePhoto(Stream photo)
        {
            try
            {
                var descReturn = await client.AnalyzeImageInDomainAsync(photo, landmark_model);

                if (!(descReturn.Result is JContainer container))
                    return null;

                var landmarks = container.ToObject<AllLandmarks>();

                return landmarks;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AllCelebrities> FindCelebrities(Stream photo, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();

                photo.Position = 0;

                var descReturn = await client.AnalyzeImageInDomainAsync(photo, celebrity_model);

                if (!(descReturn.Result is JContainer container))
                    return null;

                var celebrities = container.ToObject<AllCelebrities>();

                return celebrities;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> OCRPhoto(Stream photo, string originLanguage)
        {
            try
            {
                var theFullReturn = new StringBuilder();

                var textReturn = await client.RecognizeTextAsync(photo, originLanguage);

                foreach (var item in textReturn.Regions)
                {
                    foreach (var line in item.Lines)
                    {
                        foreach (var word in line.Words)
                        {
                            theFullReturn.Append($"{word.Text} ");
                        }
                        theFullReturn.AppendLine();
                    }
                }

                if (theFullReturn.Length == 0)
                    theFullReturn.Append(could_not_analyze);

                return theFullReturn.ToString();
            }
            catch (Exception ex)
            {
                return could_not_analyze;
            }
        }


    }
}
