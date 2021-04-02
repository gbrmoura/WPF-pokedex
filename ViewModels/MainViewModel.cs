using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using pokedex.Utils;
using Newtonsoft.Json;
using pokedex.Models;

namespace pokedex.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private PokemonOffsetLimit page_resource;
        private List<Pokemon> pokemon_list;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public MainViewModel() {
            try {
                page_resource = new PokemonOffsetLimit {
                    count = 0,
                    next = "",
                    previous = ""
                };

                PokemonList = new List<Pokemon>();
                
                var response_page_resource = HttpRequest.HttpGetRequest("https://pokeapi.co/api/v2/pokemon?limit30&offset=0");
                page_resource = JsonConvert.DeserializeObject<PokemonOffsetLimit>(response_page_resource);


                foreach(BaseNameUrl result in page_resource.results) {

                    try {
                        var response = HttpRequest.HttpGetRequest(result.url);
                        var pokemon = JsonConvert.DeserializeObject<Pokemon>(response);
                        PokemonList.Add(pokemon);
                    } catch (Exception e) {
                        Console.WriteLine("error " + e.Message);
                    }
                }

            } catch (Exception e) {
                Console.WriteLine("error " + e.Message);
            }
        }

        
        public List<Pokemon> PokemonList {
            get { return pokemon_list; }
            set { pokemon_list = value;  OnPropertyChanged("PokemonList"); }
        }
    }
}
