using System;
using Newtonsoft.Json;

namespace pokedex.Class {
    public class BaseContent {

        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("url")]
        public String Url { get; set; }
    }
}
