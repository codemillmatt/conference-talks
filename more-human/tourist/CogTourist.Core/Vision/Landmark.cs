using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace CogTourist.Core
{
    public class Landmark
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public class AllLandmarks
    {
        [JsonProperty("landmarks")]
        public List<Landmark> Landmarks { get; set; }
    }
}
