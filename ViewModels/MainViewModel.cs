using System.ComponentModel;
using System.Windows.Controls;
using pokedex.Views;

namespace pokedex.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {

        private UserControl _frameContent;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public MainViewModel() {

        }

        public UserControl FrameContent {
            get { return _frameContent; }
            set { _frameContent = value; OnPropertyChanged("FrameContent"); }
        }


    }
}
