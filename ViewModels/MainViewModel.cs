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
       
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Pokemon> _pokemonList;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public MainViewModel()
        {
            _pokemonList = new List<Pokemon>();
            loadData(150);
        }

        private void loadData(int qtqPokemons)
        {
            for (var i = 1; i < qtqPokemons+1; i++)
            {
                var response = HttpRequest.HttpGetRequest("https://pokeapi.co/api/v2/pokemon/" + i);
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(response);
                PokemonList.Add(pokemon);
            }
        }

        public List<Pokemon> PokemonList
        {
            get { return _pokemonList; }
            set { _pokemonList = value; }
        }
    }
}
