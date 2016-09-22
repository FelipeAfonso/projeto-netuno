using ModelLib;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private Dictionary<Produto, int> cache = new Dictionary<Produto, int>();
        private double valortotal {
            get {
                double t = 0;
                foreach (Produto p in cache.Keys) {
                    t += p.PrecoVista * cache[p];
                }
                return t;
            }
        }
        private bool loaded = false;

        public PontoVendaWindow() {
            InitializeComponent();
        }

        private void AutoCompleteBoxBusca_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {

            }
        }

        private void textBoxQuantidade_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            FocusManager.SetFocusedElement(GridInput, AutoCompleteBoxBusca);
        }

        private void Window_ContentRendered(object sender, EventArgs e) {
            AutoCompleteBoxBusca.ItemFilter += (s, o) => (o as Produto).Codigo.ToString().Contains(s) || (o as Produto).Nome.Contains(s);
            var ctx = new ERPDBModelContainer();
            AutoCompleteBoxBusca.ItemsSource = ctx.ProdutoSet.ToList();
            labelName.Content = Controller.LoggedUser.Nome;
            loaded = true;
            ctx.Dispose();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !Controller.IsTextAllowed(e.Text);
        }

        private void buttonAdicionar_Click(object sender, RoutedEventArgs e) {
            if (textBoxQuantidade.Text != "" && AutoCompleteBoxBusca.Text != "") {
                try {
                    var p = (Produto)AutoCompleteBoxBusca.SelectedItem;
                    if (cache.Keys.Contains(p)) {
                        cache[p] += Int32.Parse(textBoxQuantidade.Text);
                    } else { cache.Add(p, Int32.Parse(textBoxQuantidade.Text)); }
                    dataGridProdutos.ItemsSource = null;
                    dataGridProdutos.ItemsSource = cache;
                    textBlockValorTotal.Text = String.Format("R$ {0:0.00}", valortotal);
                } catch { MessageBox.Show("Produto Inválido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error); }
            } else {
                MessageBox.Show("Todos os campos devem ser preenchidos para adicionar uma venda", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RadioButtonDinheiro_Unchecked(object sender, RoutedEventArgs e) {
            if (loaded) {
                RadioButtonPrazo.IsEnabled = true;
                RadioButtonVista.IsEnabled = true;
            }
        }

        private void RadioButtonDinheiro_Checked(object sender, RoutedEventArgs e) {
            if (loaded) {
                RadioButtonPrazo.IsEnabled = false;
                RadioButtonVista.IsEnabled = false;
            }
        }

        private void RadioButtonPrazo_Checked(object sender, RoutedEventArgs e) {
            if (loaded) {
                DataGridColumnVista.Visibility = Visibility.Collapsed;
                DataGridColumPrazo.Visibility = Visibility.Visible;
            }
        }

        private void RadioButtonPrazo_Unchecked(object sender, RoutedEventArgs e) {
            if (loaded) {
                DataGridColumnVista.Visibility = Visibility.Visible;
                DataGridColumPrazo.Visibility = Visibility.Collapsed;
            }
        }

        private void buttonSalvar_Click(object sender, RoutedEventArgs e) {
            if (dataGridProdutos.Items.Count > 0) {
                using (var ctx = new ERPDBModelContainer()) {
                    //List<Venda> vset = ctx.VendaSet.ToList();
                    var venda = new Venda() {
                        Data = DateTime.Now,
                        Funcionario = null,//Controller.LoggedUser,
                        Total = valortotal
                    };
                    //ctx.UsuarioSet.Attach(venda.Funcionario);
                    //ctx.VendaSet.Add(venda);
                    var l = new List<ProdutoVendaItem>();
                    //Entities in 'ERPDBModelContainer.ProdutoVendaItemSet' participate in the 
                    //'VendaProdutoVendaItem' relationship. 0 related 'Venda' were found. 1 'Venda' is expected.
                    foreach (KeyValuePair<Produto, int> pair in cache) {
                        var pr = ctx.ProdutoSet.Single(p => p.Id == pair.Key.Id);
                        var pvi = new ProdutoVendaItem() { Produto = pr, Quantidade = pair.Value, Venda = null };
                        ctx.ProdutoSet.Attach(pr);
                        //ctx.VendaSet.Attach(pvi.Venda);
                        //ctx.ProdutoVendaItemSet.Add(pvi);
                        //ctx.ProdutoVendaItemSet.Attach(pvi);
                        ctx.ProdutoSet.Single(p => p.Id == pair.Key.Id).Quantidade -= pair.Value;
                        l.Add(pvi);
                    }
                    //((Funcionario)ctx.UsuarioSet.First(o=>o.Id == Controller.LoggedUser.Id)).Venda.Add(venda);
                    //ctx.VendaSet.Attach(venda);
                    //ctx.VendaSet.RemoveRange(ctx.VendaSet.Where(o=>o.Id>venda.Id));
                    
                    //venda.ProdutoVendaItem.Concat(l);
                    venda.ProdutoVendaItem = l;
                    ctx.UsuarioSet.OfType<Funcionario>().Single(o=>o.Id == Controller.LoggedUser.Id).Venda.Add(venda);
                    ctx.SaveChanges();
                }
                if (MessageBox.Show("Venda Cadastrada com Sucesso\nDeseja cadastrar outra venda?", "Sucesso",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes) {
                    cache.Clear();
                    AutoCompleteBoxBusca.Text = "";
                    textBoxQuantidade.Clear();
                    dataGridProdutos.ItemsSource = null;
                    dataGridProdutos.ItemsSource = cache;
                    textBlockValorTotal.Text = String.Format("R$ {0:0.00}", valortotal);
                } else {
                    Close();
                }

            } else {
                MessageBox.Show("Precisa de pelo menos um produto para realizar uma venda", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonRemover_Click(object sender, RoutedEventArgs e) {
            foreach (Produto prod in this.dataGridProdutos.SelectedItems) {
                cache.Remove(prod);
                dataGridProdutos.ItemsSource = null;
                dataGridProdutos.ItemsSource = cache;
            }
        }

        private void buttonLimpar_Click(object sender, RoutedEventArgs e) {
            cache.Clear();
            dataGridProdutos.ItemsSource = null;
            dataGridProdutos.ItemsSource = cache;
        }
    }
}
