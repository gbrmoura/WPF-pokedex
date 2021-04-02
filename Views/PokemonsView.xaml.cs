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
    /// Interação lógica para PokemonsView.xam
    /// </summary>
    public partial class PokemonsView : Page {

        private PokemonsViewModel ViewModel;
        public PokemonsView() {
            InitializeComponent();
            ViewModel = new PokemonsViewModel();
            this.DataContext = ViewModel;
        }
    }
}
