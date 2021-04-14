using System.ComponentModel;
using pokedex.Views;
using pokedex.ViewModels;
using pokedex.Models;
using pokedex.Utils;
using pokedex.Commands;
using System;
using Newtonsoft.Json;

namespace pokedex.ViewModels {
    class PokemonDescripitionViewModel : INotifyPropertyChanged {

        private Pokemon _pokemon;
        private RelayCommand _rollBack;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public PokemonDescripitionViewModel(int id) {
            try {
                _pokemon = new Pokemon();
                _rollBack = new RelayCommand(back);


                var response_pokemon = HttpRequest.HttpGetRequest($"https://pokeapi.co/api/v2/pokemon/{ id }");
                this.Pokemon = JsonConvert.DeserializeObject<Pokemon>(response_pokemon);

            } catch (Exception e) {
                Console.WriteLine("erro while trying to request pokemon - " + e.Message);
            }
        }


        public RelayCommand RollBack {
            get { return _rollBack; }
        }

        public Pokemon Pokemon {
            get { return _pokemon; }
            set { _pokemon = value; OnPropertyChanged("Pokemon"); }
        }


        public void back() {
            MainViewModel.GetInstance().FrameContent = new PokemonsView();
        }

    }
}
