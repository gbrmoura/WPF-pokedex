using System.Windows.Controls;
using pokedex.ViewModels;

namespace pokedex.Views {
    /// <summary>
    /// Interação lógica para PokemonDescripitonView.xam
    /// </summary>
    public partial class PokemonDescripitonView : UserControl {
        public PokemonDescripitonView() {
            InitializeComponent();
        }

        public PokemonDescripitonView(int pokemonID) {
            InitializeComponent();
            this.DataContext = new PokemonDescripitionViewModel(pokemonID);
        }
    }
}
