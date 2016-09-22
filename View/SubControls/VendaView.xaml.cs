using ModelLib;
using ModelLib.Adapters;
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
            if (Controller.LoggedUser is Administrador
                || Controller.LoggedUser.Permissao.FirstOrDefault(o => o.Descricao == Controller.Permissoes["LançarVendas"].Descricao) != null) {
                ButtonCancelar.IsEnabled = true;
                ButtonPontoVenda.IsEnabled = true;
            }
        }

        private void Update(object sender, RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            var l = new List<VendaAdapter>();
            foreach (var v in context.VendaSet.ToList()) {
                l.Add(new VendaAdapter(v));
            }
            DataGridVendas.ItemsSource = (l.Count > 0) ? l : null;
        }

        private void PontoVendaButtonClick(object sender, RoutedEventArgs e) {
            if (p == null) {
                p = new PontoVendaWindow();
                p.Closed += (a, b) => p = null;
                p.buttonSalvar.Click += Update;
                p.Show();
            } else if (p.IsVisible) p.Focus();
            else p.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            Update(sender, e);
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e) {
            if (Controller.LoggedUser.GetType() == typeof(Administrador)
                || Controller.LoggedUser.Permissao.Contains(Controller.Permissoes["EditarVendas"])) {
                var context = new ERPDBModelContainer();
                foreach (VendaAdapter venda in DataGridVendas.SelectedItems) {
                    var v = context.VendaSet.Single(o => o.Id == venda.Id);
                    var l = new List<ProdutoVendaItem>();
                    //v.Funcionario = null;
                    v.Cliente = null;
                    foreach (ProdutoVendaItem pvi in v.ProdutoVendaItem) {
                        l.Add(pvi); if (pvi.Produto!=null) context.ProdutoSet.Single(o => o.Id == pvi.Produto.Id).Quantidade += pvi.Quantidade;
                    }
                    context.ProdutoVendaItemSet.RemoveRange(l);
                    context.VendaSet.Remove(v);
                }
                context.SaveChanges();
                Update(sender, e);
            } else {
                var t = true;
                foreach (Venda v in DataGridVendas.SelectedItems) {
                    if (v.Funcionario != Controller.LoggedUser) t = false;
                }
                if (t) {
                    var context = new ERPDBModelContainer();
                    foreach (VendaAdapter venda in DataGridVendas.SelectedItems) {
                        var l = new List<ProdutoVendaItem>();
                        var v = context.VendaSet.Single(o => o.Id == venda.Id);
                        v.Funcionario = null;
                        v.Cliente = null;
                        foreach (ProdutoVendaItem pvi in v.ProdutoVendaItem) {
                            l.Add(pvi); context.ProdutoSet.Single(o => o.Id == pvi.Produto.Id).Quantidade += pvi.Quantidade;
                        }
                        context.ProdutoVendaItemSet.RemoveRange(l);
                        context.VendaSet.Remove(v);
                    }
                    context.SaveChanges();
                    Update(sender, e);
                }
            }
        }
    }
}
