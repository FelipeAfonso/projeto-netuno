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

namespace View.UserControls {
    /// <summary>
    /// Interaction logic for VendaView.xaml
    /// </summary>
    public partial class VendaView : UserControl {

        private PontoVendaWindow p;

        public VendaView() {
            InitializeComponent();
        }

        private void PontoVendaButtonClick(object sender, RoutedEventArgs e) {
            if(p == null) {
                p = new PontoVendaWindow();
                p.Closed += (a, b) => p = null;
                p.Show();
            }
            else if (p.IsVisible) p.Focus();
            else p.Show();
        }
    }
}
