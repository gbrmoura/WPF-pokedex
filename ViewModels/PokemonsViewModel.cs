using System;
using System.ComponentModel;
using pokedex.Utils;
using Newtonsoft.Json;
using pokedex.Models;
using pokedex.Commands;
using pokedex.Class;
using System.Collections.ObjectModel;

namespace pokedex.ViewModels
{
    class PokemonsViewModel : INotifyPropertyChanged {

        private const String _firstRequest = "https://pokeapi.co/api/v2/pokemon?limit30&offset=0";

        private PokemonOffsetLimit _pageResource;
        private ObservableCollection<PokemonCard> _pokemonList;
        private RelayCommand _nextCommand;
        private RelayCommand _previousCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public PokemonsViewModel() {
            try {
                _pageResource = new PokemonOffsetLimit();
                _pokemonList = new ObservableCollection<PokemonCard>();
                _nextCommand = new RelayCommand(Next);
                _previousCommand = new RelayCommand(Previous);

                ExecuteRequest(_firstRequest);
            } catch (Exception e) {
                Console.WriteLine("error " + e.Message);
            }
        }

        public PokemonOffsetLimit PageResource {
            get { return _pageResource; }
            set { _pageResource = value; OnPropertyChanged("PageResource"); }
        }


        public ObservableCollection<PokemonCard> PokemonList {
            get { return _pokemonList; }
            set { _pokemonList = value; OnPropertyChanged("PokemonList"); }
        }

        public RelayCommand NextCommand {
            get { return _nextCommand; }
        }

        public RelayCommand PreviousCommand {
            get { return _previousCommand; }
        }

        public void ExecuteRequest(String url) {

            try {
                var response_page_resource = HttpRequest.HttpGetRequest(url);
                this._pageResource = JsonConvert.DeserializeObject<PokemonOffsetLimit>(response_page_resource);
                this.PokemonList.Clear();

                foreach ( BaseContent content in _pageResource.results) {

                    try {
                        var response = HttpRequest.HttpGetRequest(content.Url);
                        var pokemon = JsonConvert.DeserializeObject<PokemonCard>(response);
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
            ExecuteRequest(PageResource.next);
        }

        public void Previous() {
            ExecuteRequest(PageResource.previous);
        }


    }
}
