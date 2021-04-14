using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pokedex.Commands {
    public class SelectPokemonCommand : ICommand {
        public event EventHandler CanExecuteChanged;
        private Action<Int32> _execute;

        public SelectPokemonCommand(Action<Int32> execute) {
            _execute = execute;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            _execute.Invoke((Int32)parameter);  
        }
    }
}
