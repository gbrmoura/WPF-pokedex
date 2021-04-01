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
    public class PokemonPageUserControlViewModel : INotifyPropertyChanged
    {

        public PokemonPageUserControlViewModel()
        {
            _pokemonList = new List<Pokemon>();
            loadData();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        private void loadData()
        {
            for (var i = 1; i < 10; i++)
            {
                var response = HttpRequest.HttpGetRequest("https://pokeapi.co/api/v2/pokemon/"+i);
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(response);
                PokemonList.Add(pokemon);
            }
        }

        private String Color(String type)
        {
            return PokemonUtils.TypeColor(type);
        }

        private Pokemon _pokemon;

        public Pokemon Pokemon
        {
            get { return _pokemon; }
            set { _pokemon = value; OnPropertyChanged("Pokemon"); }
        }

        private List<Pokemon> _pokemonList;

        public List<Pokemon> PokemonList
        {
            get { return _pokemonList; }
            set { _pokemonList = value; }
        }


    }
}
