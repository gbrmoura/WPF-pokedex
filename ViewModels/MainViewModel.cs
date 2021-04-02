using System.ComponentModel;
using System.Windows.Controls;
using pokedex.Views;

namespace pokedex.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged {
        
        private Page frame_content;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public MainViewModel() {
            FrameContent = new PokemonsView();    
        }

        public Page FrameContent {
            get { return frame_content; }
            set { frame_content = value; OnPropertyChanged("FrameContent"); }
        }


    }
}
