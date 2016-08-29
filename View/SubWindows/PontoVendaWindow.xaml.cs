using ModelLib;
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

namespace View {
    /// <summary>
    /// Interaction logic for PontoVendaWindow.xaml
    /// </summary>
    public partial class PontoVendaWindow : Window {
        public PontoVendaWindow() {
            InitializeComponent();
        }

        private void AutoCompleteBoxBusca_KeyDown(object sender, KeyEventArgs e) {
            if(e.Key == Key.Enter) {
                //if (e.Key == Key.Enter & (sender as TextBox).AcceptsReturn == false) MoveToNextUIElement(e);
            }
        }

        private void textBoxQuantidade_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                //if (e.Key == Key.Enter & (sender as TextBox).AcceptsReturn == false) MoveToNextUIElement(e);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            FocusManager.SetFocusedElement(GridInput, AutoCompleteBoxBusca);
        }
    }
}
