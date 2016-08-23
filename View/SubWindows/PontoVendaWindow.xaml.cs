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

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            base.OnClosing(e);
            this.Hide();
        }

    }
}
