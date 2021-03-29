using System;
using Newtonsoft.Json;

namespace pokedex.Models
{
    public class PokemonList
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("next")]
        public String next { get; set; }
        [JsonProperty("previous")]
        public String previous { get; set; }
        [JsonProperty("results")]
        public Result[] results { get; set; }
    }

    public class Result
    {
        [JsonProperty("name")]
        public String name { get; set; }
        [JsonProperty("url")]
        public String url { get; set; }
    }
    
}
