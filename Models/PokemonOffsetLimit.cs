using System;
using Newtonsoft.Json;
using pokedex.Class; 

namespace pokedex.Models {
    public class PokemonOffsetLimit {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("next")]
        public String next { get; set; }
        [JsonProperty("previous")]
        public String previous { get; set; }
        [JsonProperty("results")]
        public BaseContent[] results { get; set; }
    }
}
