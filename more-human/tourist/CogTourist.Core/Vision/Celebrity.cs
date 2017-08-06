using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace CogTourist.Core
{
    public class Celebrity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }
    }
 
    public class AllCelebrities
    {
        [JsonProperty("celebrities")]
        public List<Celebrity> Celebrities { get; set; }
    }

}
