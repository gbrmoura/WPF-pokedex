using System.ComponentModel;
using System.Windows.Controls;
using System;
using System.Collections.ObjectModel;
using pokedex.Views;


namespace pokedex.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {

        private UserControl _frameContent;
        private static MainViewModel _instance;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private MainViewModel() {
            _frameContent = new PokemonsView();
        }

        public static MainViewModel GetInstance() {
            if (_instance == null) {
                _instance = new MainViewModel();
            }
            return _instance;
        } 
        
        public static void DestroyInstance() {
            _instance = null;
        }

        public UserControl FrameContent {
            get { return _frameContent; }
            set { _frameContent = value; OnPropertyChanged("FrameContent"); }
        }


    }
}
