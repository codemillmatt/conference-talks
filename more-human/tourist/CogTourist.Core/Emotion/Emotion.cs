using System;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace CogTourist.Core
{
    public class Scores
    {
        [JsonProperty("anger")]
        public double Anger { get; set; }

        [JsonProperty("contempt")]
        public double Contempt { get; set; }

        [JsonProperty("disgust")]
        public double Disgust { get; set; }

        [JsonProperty("fear")]
        public double Fear { get; set; }

        [JsonProperty("happiness")]
        public double Happiness { get; set; }

        [JsonProperty("neutral")]
        public double Neutral { get; set; }

        [JsonProperty("sadness")]
        public double Sadness { get; set; }

        [JsonProperty("surprise")]
        public double Surprise { get; set; }
    }

    public class Emotion
    {
        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("scores")]
        public Scores Scores { get; set; }

        public string GetMainEmotion()
        {
            var allScores = new List<EmotionScore>
            {
                new EmotionScore{Emotion="Angry",Score=Scores.Anger},
                new EmotionScore{Emotion="Contempt",Score = Scores.Contempt},
                new EmotionScore{Emotion="Disgusted",Score=Scores.Disgust},
                new EmotionScore{Emotion="Afraid",Score=Scores.Fear},
                new EmotionScore{Emotion="Happy",Score=Scores.Happiness},
                new EmotionScore{Emotion="Sad",Score=Scores.Sadness},
                new EmotionScore{Emotion="Surprised",Score=Scores.Surprise}
            };

            return allScores.OrderByDescending(score => score.Score).First().Emotion;
        }
    }

    public class FaceRectangle
    {
        [JsonProperty("left")]
        public int Left { get; set; }

        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    class EmotionScore
    {
        public string Emotion { get; set; }
        public double Score { get; set; }
    }
}
