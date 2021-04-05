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
using System.Windows.Shapes;
using pokedex.ViewModels;
using pokedex.Views;

namespace pokedex.Views {
    /// <summary>
    /// Lógica interna para MainView.xaml
    /// </summary>
    public partial class MainView : Window {
        MainViewModel ViewModel;

        public MainView() {
            InitializeComponent();
            ViewModel = new MainViewModel();
            this.DataContext = ViewModel;
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnMaximizade_Click(object sender, RoutedEventArgs e) {
            if (this.WindowState == WindowState.Maximized) {
                this.WindowState = WindowState.Normal;
            } else {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void btnMinimazed_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }
    }
}
