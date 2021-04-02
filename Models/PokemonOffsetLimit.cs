using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pokedex.Models
{
    public class PokemonOffsetLimit
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("next")]
        public String next { get; set; }
        [JsonProperty("previous")]
        public String previous { get; set; }
        [JsonProperty("results")]
        public BaseNameUrl[] results { get; set; }
    }
}
