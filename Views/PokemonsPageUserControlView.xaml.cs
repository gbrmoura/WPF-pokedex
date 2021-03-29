using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using pokedex.ViewModels;

namespace pokedex.Views
{
    /// <summary>
    /// Interação lógica para PokemonsPageUserControlView.xam
    /// </summary>
    public partial class PokemonsPageUserControlView : UserControl
    {
        PokemonPageUserControlViewModel ViewModel;
        public PokemonsPageUserControlView()
        {
            InitializeComponent();
            ViewModel = new PokemonPageUserControlViewModel();
            this.DataContext = ViewModel;
        }
    }
}
