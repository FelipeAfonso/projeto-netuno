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
            if(Controller.LoggedUser.GetType() == typeof(Administrador)
                || Controller.LoggedUser.Permissao.Contains(Controller.Permissoes["LançarVendas"])) {
                ButtonCancelar.IsEnabled = true;
                ButtonPontoVenda.IsEnabled = true;
            }
        }

        private void Update(object sender, RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            DataGridVendas.ItemsSource = (context.VendaSet.ToList().Count > 0) ? context.VendaSet.ToList() : null;
            //context.Dispose();
        }

        private void PontoVendaButtonClick(object sender, RoutedEventArgs e) {
            if(p == null) {
                p = new PontoVendaWindow();
                p.Closed += (a, b) => p = null;
                p.buttonSalvar.Click += Update;
                p.Show();
            }
            else if (p.IsVisible) p.Focus();
            else p.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            Update(sender, e);
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e) {
            if (Controller.LoggedUser.GetType() == typeof(Administrador)
                || Controller.LoggedUser.Permissao.Contains(Controller.Permissoes["EditarVendas"])) {
                var context = new ERPDBModelContainer();
                foreach (Venda venda in DataGridVendas.SelectedItems) {
                    var v = context.VendaSet.Single(o => o.Id == venda.Id);
                    context.VendaSet.Remove(v);
                }
                context.SaveChanges();
                Update(sender, e);
            } else {
                var t = true;
                foreach (Venda v in DataGridVendas.SelectedItems) {
                    if(v.Funcionario != Controller.LoggedUser) t = false;
                }
                if (t) {
                    var context = new ERPDBModelContainer();
                    foreach (Venda venda in DataGridVendas.SelectedItems) {
                        var v = context.VendaSet.Single(o => o.Id == venda.Id);
                        context.VendaSet.Remove(v);
                    }
                    context.SaveChanges();
                    Update(sender, e);
                }
            }
        }
    }
}
