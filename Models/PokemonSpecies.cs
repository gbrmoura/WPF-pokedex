using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pokedex.Models
{
    public class PokemonSpecies
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("color")]
        public BaseNameUrl color { get; set; }
        [JsonProperty("name")]
        public String name { get; set; }
    }

}
