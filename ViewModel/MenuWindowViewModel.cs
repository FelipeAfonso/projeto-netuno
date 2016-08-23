using ModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel {
    public class MenuWindowViewModel {

        private bool _canExecute;
        private ICommand _vendasClickCommand;

        public MenuWindowViewModel() {
            _canExecute = true;
        }

        public String WindowTitle { get {
                return "Undertow - " + Globals.Instance.NomeEmpresa;
            }
        }

        public Grid ControlGrid { get; set; }

        public ICommand VendasClickCommand { get { return _vendasClickCommand ?? (_vendasClickCommand = new CommandHandler(() => VendasClickAction(), _canExecute)); } }

        public void VendasClickAction() {
            ControlGrid.Children.Clear();

            ControlGrid.Children.Add(new )
        }
    }

    public class CommandHandler : ICommand {
        private Action _action;
        private bool _canExecute;

        public CommandHandler(Action action, bool canExecute) {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) {
            _action();
        }
    }
}
