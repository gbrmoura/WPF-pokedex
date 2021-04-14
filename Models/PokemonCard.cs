using Newtonsoft.Json;
using pokedex.Class;
using System;

namespace pokedex.Models {
    public class PokemonCard {

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
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
        public String Front_Default { get; set; }
        [JsonProperty("back_default")]
        public String Back_Default { get; set; }
        [JsonProperty("other")]
        public PokemonCardOther Other { get; set; }
    }

    public class PokemonCardOther {
        [JsonProperty("dream_world")]
        public PokemonCardDreamWorld Dream_World { get; set; }
        [JsonProperty("official-artwork")]
        public PokemonCardOfficialArtWork Official_Artwork { get; set; }
    }

    public class PokemonCardDreamWorld {
        [JsonProperty("front_default")]
        public String Front_Default { get; set; }
        [JsonProperty("front_female")]
        public String Front_Female { get; set; }
    }

    public class PokemonCardOfficialArtWork {
        [JsonProperty("front_default")]
        public String Front_Default { get; set; }
    }

}
