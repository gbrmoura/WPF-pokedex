using System;
using System.Windows.Controls;
using pokedex.ViewModels;


namespace pokedex.Views {
    /// <summary>
    /// Interação lógica para PokemonsView.xam
    /// </summary>
    public partial class PokemonsView : UserControl {
        private PokemonsViewModel ViewModel; 
        public PokemonsView() {
            InitializeComponent();
            ViewModel = new PokemonsViewModel();
            this.DataContext = ViewModel;
        }
    }
}
