using System;
using System.Windows.Controls;
using pokedex.ViewModels;


namespace pokedex.Views {
    /// <summary>
    /// Interação lógica para PokemonsView.xam
    /// </summary>
    public partial class PokemonsView : UserControl {
        public PokemonsView() {
            InitializeComponent();
            this.DataContext = new PokemonsViewModel(); ;
        }
    }
}
