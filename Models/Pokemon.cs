using System;
using Newtonsoft.Json;
using pokedex.Class;

namespace pokedex.Models {
    public class Pokemon {
        [JsonProperty("abilities")]
        public Abilities[] abilities { get; set; }
        [JsonProperty("base_experience")]
        public int base_experience { get; set; }
        [JsonProperty("forms")]
        public BaseContent[] forms { get; set; }
        [JsonProperty("game_indices")]
        public GameIndices[] game_indices { get; set; }
        [JsonProperty("height")]
        public int heigth { get; set; }
        [JsonProperty("held_items")]
        public HeldItems[] held_items { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("is_default")]
        public bool is_default { get; set; }
        [JsonProperty("location_area_encounters")]
        public String location_area_encounters { get; set; }
        [JsonProperty("moves")]
        public Moves[] moves { get; set; }
        [JsonProperty("name")]
        public String name { get; set; }
        [JsonProperty("order")]
        public int order { get; set; }
        [JsonProperty("past_types")]
        public PastTypes[] past_types { get; set; }
        [JsonProperty("species")]
        public BaseContent species { get; set; }
        [JsonProperty("sprites")]
        public Sprites sprites { get; set; }
        [JsonProperty("stats")]
        public Stats[] stats { get; set; }
        [JsonProperty("types")]
        public Types[] types { get; set; }
        [JsonProperty("weight")]
        public int weigth { get; set; }

    }

    public class Abilities {
        [JsonProperty("ability")]
        public BaseContent ability { get; set; }
        [JsonProperty("is_hidden")]
        public bool is_hidden { get; set; }
        [JsonProperty("slot")]
        public int slot { get; set; }

    }

    public class GameIndices {
        [JsonProperty("game_index")]
        public int game_indixe { get; set; }
        [JsonProperty("version")]
        public BaseContent version { get; set; }
    }


    public class HeldItems {
        [JsonProperty("item")]
        public BaseContent item { get; set; }
        [JsonProperty("version_details")]
        public VersionDetails[] version_details { get; set; }
    }

    public class VersionDetails {
        [JsonProperty("rarity")]
        public int rarity { get; set; }
        [JsonProperty("version")]
        public BaseContent version { get; set; }
    }

    public class Moves {
        [JsonProperty("move")]
        public BaseContent move { get; set; }
        [JsonProperty("version_group_details")]
        public VersionGroupDetails[] version_group_details { get; set; }
    }

    public class VersionGroupDetails {
        [JsonProperty("level_learned_at")]
        public int level_learned_at { get; set; }
        [JsonProperty("move_learn_method")]
        public BaseContent move_learn_method { get; set; }
        [JsonProperty("version_group")]
        public BaseContent version_group { get; set; }
    }

    public class PastTypes {
        [JsonProperty("generation")]
        public BaseContent generation { get; set; }
        [JsonProperty("types")]
        public Types[] types { get; set; }

    }

    public class Types {
        [JsonProperty("slot")]
        public int slot { get; set; }
        [JsonProperty("type")]
        public BaseContent type { get; set; }
    }
    public class Sprites {
        [JsonProperty("back_default")]
        public String back_default { get; set; }
        [JsonProperty("back_female")]
        public String back_female { get; set; }
        [JsonProperty("back_shiny")]
        public String back_shiny { get; set; }
        [JsonProperty("back_shiny_female")]
        public String back_shiny_female { get; set; }
        [JsonProperty("front_default")]
        public String front_default { get; set; }
        [JsonProperty("front_female")]
        public String front_female { get; set; }
        [JsonProperty("front_shiny")]
        public String front_shiny { get; set; }
        [JsonProperty("front_shiny_female")]
        public String front_shiny_female { get; set; }
        [JsonProperty("other")]
        public Other other { get; set; }
    }

    public class Other {
        [JsonProperty("dream_world")]
        public DreamWorld dream_world { get; set; }
        [JsonProperty("official-artwork")]
        public OfficialArtWork official_artwork { get; set; }
    }

    public class DreamWorld {
        [JsonProperty("front_default")]
        public String front_default { get; set; }
        [JsonProperty("front_female")]
        public String front_female { get; set; }
    }

    public class OfficialArtWork {
        [JsonProperty("front_default")]
        public String front_default { get; set; }
    }


    public class Stats {
        [JsonProperty("base_stat")]
        public int base_stat { get; set; }
        [JsonProperty("effort")]
        public int effort { get; set; }
        [JsonProperty("stat")]
        public BaseContent stat { get; set; }
    }

}