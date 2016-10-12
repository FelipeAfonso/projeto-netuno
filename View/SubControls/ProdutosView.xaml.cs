using ModelLib;
using ModelLib.Adapters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
using View.CustomControls;
using View.SubWindows;

namespace View.UserControls {
    /// <summary>
    /// Interaction logic for ProdutosView.xaml
    /// </summary>
    /// 
    public partial class ProdutosView : UserControl {

        private AdicionarProdutoWindow p;

        public ProdutosView() {
            InitializeComponent();
            if (Controller.LoggedUser is Administrador
                || Controller.LoggedUser.Permissao.FirstOrDefault(o => o.Descricao == Controller.Permissoes["GerenciarProdutos"].Descricao) != null) {
                ButtonAdicionar.IsEnabled = true;
                ButtonDeletar.IsEnabled = true;
                ButtonEditar.IsEnabled = true;
            }
            if (Controller.LoggedUser is Administrador
                || Controller.LoggedUser.Permissao.FirstOrDefault(o => o.Descricao == Controller.Permissoes["GerenciarEstoque"].Descricao) != null) {
                ButtonEstoque.IsEnabled = true;
            }
        }

        private void ButtonAdicionar_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (p == null) {
                p = new AdicionarProdutoWindow();
                p.Closed += (a, b) => p = null;
                p.buttonAdd.Click += Update;
                p.Show();
            } else if (p.IsVisible) p.Focus();
            else p.Show();
        }

        private void Update(object sender, RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            var l = new List<ProdutoAdapter>();
            foreach (var p in context.ProdutoSet.ToList()) {
                l.Add(new ProdutoAdapter(p));
            }
            DataGridProduto.ItemsSource = (l.Count > 0) ? l : null;
        }

        private void ButtonDeletar_Click(object sender, System.Windows.RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            foreach (ProdutoAdapter prod in DataGridProduto.SelectedItems) {
                                        var p = context.ProdutoSet.Single(o => o.Codigo == prod.Codigo);
                if (p.ProdutoVendaItem.Count > 0) {
                    if (MessageBox.Show("O produto " + p.Nome
                        + " está presente em uma ou mais vendas, se remover este produto as vendas não "
                        + "irão apresentar mais o produto. Deseja continuar?", "Autorização",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {

                        p.ProdutoVendaItem.Clear();
                        context.ProdutoSet.Remove(p);
                        Controller.Log("Deletou o Produto: " + p.Nome + " removendo-o as vendas realizadas anteriormente");

                    }
                } else {
                    context.ProdutoSet.Remove(p);
                    Controller.Log("Deletou o Produto: " + p.Nome);
                }
            }
            context.SaveChanges();
            Update(sender, e);
        }

        private void ButtonEstoque_Click(object sender, System.Windows.RoutedEventArgs e) {
            var dialog = new EstoqueDialog();
            if (dialog.ShowDialog() == true) {
                var ctx = new ERPDBModelContainer();
                ctx.ProdutoSet.First(p => p.Id == dialog.getProduto.Value.Id).Quantidade += dialog.getProduto.Key;
                ctx.SaveChanges();
                Update(sender, e);
                Controller.Log("Atualizou o Estoque: " + dialog.getProduto.Key + " " + dialog.getProduto.Value.Nome);
                MessageBox.Show("Estoque atualizado com sucesso");
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            //var ctx = new ERPDBModelContainer();
            Update(sender, e);
        }

        private void ComboBoxExibir_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems[0].GetType() != typeof(ComboBoxItem)) {
                DataGridProduto.ItemsSource = ((Categoria)e.AddedItems[0]).Produto;
            } else if (e.RemovedItems.Count > 0) {
                Update(sender, null);
            }
        }

        private void ButtonEditar_Click(object sender, RoutedEventArgs e) {
            if (DataGridProduto.SelectedItems.Count == 1) {
                if (p == null) {
                    using (var ctx = new ERPDBModelContainer()) {
                        p = new AdicionarProdutoWindow(ctx.ProdutoSet.Single(o=>o.Id==((ProdutoAdapter)DataGridProduto.SelectedItem).Id));
                    }
                    p.Closed += (a, b) => p = null;
                    p.buttonAdd.Click += Update;
                    p.Show();
                } else if (p.IsVisible) p.Focus();
                else p.Show();
            } else { MessageBox.Show("Você precisa selecionar apenas 1 Item"); }
        }
    }
}
