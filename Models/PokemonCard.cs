using Newtonsoft.Json;
using pokedex.Class;

namespace pokedex.Models {
    public class PokemonCard {

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sprites")]
        public PokemonCardSprites Sprites { get; set; }
        [JsonProperty("types")]
        public PokemonCardType[] Types { get; set; }
    }

    public class PokemonCardType {
        [JsonProperty("slot")]
        public int Slot { get; set; }
        [JsonProperty("type")]
        public BaseContent Type { get; set; }
    }

    public class PokemonCardSprites {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }
        [JsonProperty("back_default")]
        public string BackDefault { get; set; }
    }


}
