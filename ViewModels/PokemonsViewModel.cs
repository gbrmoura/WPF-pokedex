using System;
using System.ComponentModel;
using pokedex.Utils;
using Newtonsoft.Json;
using pokedex.Models;
using pokedex.Commands;
using pokedex.Class;
using pokedex.ViewModels;
using pokedex.Views;
using System.Collections.ObjectModel;

namespace pokedex.ViewModels
{
    public class PokemonsViewModel : INotifyPropertyChanged {

        private const String _firstRequest = "https://pokeapi.co/api/v2/pokemon?limit3&offset=0";

        private PokemonOffsetLimit _pageResource;
        private ObservableCollection<PokemonCard> _pokemonList;
        private RelayCommand _nextCommand;
        private RelayCommand _previousCommand;
        private SelectPokemonCommand _selectCommand;

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
                _selectCommand = new SelectPokemonCommand(Select);

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

        public SelectPokemonCommand SelectCommand {
            get { return _selectCommand; }
        }

        public void ExecuteRequest(String url) {

            try {
                if (String.IsNullOrEmpty(url)) {
                    throw new Exception();
                } 

                this._pageResource = JsonConvert.DeserializeObject<PokemonOffsetLimit>(HttpRequest.HttpGetRequest(url));
                this._pokemonList.Clear();

                foreach ( BaseContent content in _pageResource.results) {

                    try {
                        this._pokemonList.Add(JsonConvert.DeserializeObject<PokemonCard>(HttpRequest.HttpGetRequest(content.Url)));
                    } catch (Exception e) {
                        Console.WriteLine("error while tryng to insert pokemon - " + e.Message);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("error while tryng to request pokemons - " + e.Message);
            }
        }

        public void Next() => ExecuteRequest(PageResource.next);

        public void Previous() => ExecuteRequest(PageResource.previous);

        public void Select(int ID) {
            MainViewModel.GetInstance().FrameContent = new PokemonDescripitonView(ID);
        }


    }
}
