using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pokedex.Models
{
    public class Pokemon
    {
        [JsonProperty("abilities")]
        public Abilities[] abilities { get; set; }
        [JsonProperty("base_experience")]
        public int base_experience { get; set; }
        [JsonProperty("forms")]
        public BaseNameUrl[] forms { get; set; }
        [JsonProperty("game_indices")]
        public GameIndices[] game_indices { get; set; }
        [JsonProperty("heigth")]
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
        public BaseNameUrl species { get; set; }
        [JsonProperty("sprites")]
        public Sprites sprites { get; set; }
        [JsonProperty("stats")]
        public Stats[] stats { get; set; }
        [JsonProperty("types")]
        public Types[] types { get; set; }
        [JsonProperty("weigth")]
        public int weigth { get; set; }

    }

    public class Abilities
    {
        [JsonProperty("ability")]
        public BaseNameUrl ability { get; set; }
        [JsonProperty("is_hidden")]
        public bool is_hidden { get; set; }
        [JsonProperty("slot")]
        public int slot { get; set; }

    }

    public class GameIndices 
    {
        [JsonProperty("game_index")]
        public int game_indixe { get; set; }
        [JsonProperty("version")]
        public BaseNameUrl version { get; set; }
    }


    public class HeldItems 
    {
        [JsonProperty("item")]
        public BaseNameUrl item { get; set; }
        [JsonProperty("version_details")]
        public VersionDetails[] version_details { get; set; }
    }

    public class VersionDetails 
    {
        [JsonProperty("rarity")]
        public int rarity { get; set; }
        [JsonProperty("version")]
        public BaseNameUrl version { get; set; }
    }

    public class Moves 
    {
        [JsonProperty("move")]
        public BaseNameUrl move { get; set; }
        [JsonProperty("version_group_details")]
        public VersionGroupDetails[] version_group_details { get; set; }
    }

    public class VersionGroupDetails
    {
        [JsonProperty("level_learned_at")]
        public int level_learned_at { get; set; }
        [JsonProperty("move_learn_method")]
        public BaseNameUrl move_learn_method { get; set; }
        [JsonProperty("version_group")]
        public BaseNameUrl version_group { get; set; }
    }

    public class PastTypes
    {
        [JsonProperty("generation")]
        public BaseNameUrl generation { get; set; }
        [JsonProperty("types")]
        public Types[] types { get; set; }

    }

    public class Types
    {
        [JsonProperty("slot")]
        public int slot { get; set; }
        [JsonProperty("type")]
        public BaseNameUrl type { get; set; }
    }
    public class Sprites
    {
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
    }

    public class Stats
    {
        [JsonProperty("base_stat")]
        public int base_stat { get; set; }
        [JsonProperty("effort")]
        public int effort { get; set; }
        [JsonProperty("stat")]
        public BaseNameUrl stat { get; set; }
    }

    public class BaseNameUrl
    {
        [JsonProperty("name")]
        public String name { get; set; }
        [JsonProperty("url")]
        public String url { get; set; }
    }
}