using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokedex.Utils;
using Newtonsoft.Json;
using pokedex.Models;
using pokedex.Commands;
using System.Collections.ObjectModel;

namespace pokedex.ViewModels
{
    class PokemonsViewModel : INotifyPropertyChanged {

        private PokemonOffsetLimit page_resource;
        private ObservableCollection<Pokemon> pokemon_list;
        private RelayCommand next_command;
        private RelayCommand previous_command;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public PokemonsViewModel() {
            try {
                page_resource = new PokemonOffsetLimit();
                PokemonList = new ObservableCollection<Pokemon>();
                next_command = new RelayCommand(Next);
                previous_command = new RelayCommand(Previous);

                ExecuteRequest("https://pokeapi.co/api/v2/pokemon?limit30&offset=0");
            } catch (Exception e) {
                Console.WriteLine("error " + e.Message);
            }
        }

        public ObservableCollection<Pokemon> PokemonList {
            get { return pokemon_list; }
            set { pokemon_list = value; OnPropertyChanged("PokemonList"); }
        }

        public RelayCommand NextCommand {
            get { return next_command; }
        }

        public RelayCommand PreviousCommand {
            get { return previous_command; }
        }

        public void ExecuteRequest(String url) {

            try {
                var response_page_resource = HttpRequest.HttpGetRequest(url);
                this.page_resource = JsonConvert.DeserializeObject<PokemonOffsetLimit>(response_page_resource);
                this.PokemonList.Clear();

                foreach (BaseNameUrl result in page_resource.results) {

                    try {
                        var response = HttpRequest.HttpGetRequest(result.url);
                        var pokemon = JsonConvert.DeserializeObject<Pokemon>(response);
                        this.PokemonList.Add(pokemon);
                    } catch (Exception e) {
                        Console.WriteLine("error while tryng to insert pokemon - " + e.Message);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("error while tryng to request pokemons - " + e.Message);
            }
        }

        public void Next() {
            ExecuteRequest(page_resource.next);
        }

        public void Previous() {
            ExecuteRequest(page_resource.previous);
        }


    }
}
