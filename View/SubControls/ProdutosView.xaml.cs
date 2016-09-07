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

            if (Controller.LoggedUser.GetType() == typeof(Administrador)
                || Controller.LoggedUser.Permissao.Contains(Controller.Permissoes["GerenciarProdutos"])) {
                ButtonAdicionar.IsEnabled = true;
                ButtonDeletar.IsEnabled = true;
            }
            if (Controller.LoggedUser.GetType() == typeof(Administrador)
                || Controller.LoggedUser.Permissao.Contains(Controller.Permissoes["GerenciarEstoque"])) {
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
            DataGridProduto.ItemsSource = (context.ProdutoSet.ToList().Count > 0) ? context.ProdutoSet.ToList() : null;
        }

        private void ButtonDeletar_Click(object sender, System.Windows.RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            foreach (Produto prod in DataGridProduto.SelectedItems) {
                var p = context.ProdutoSet.Single(o => o.Codigo == prod.Codigo);
                context.ProdutoSet.Remove(p);
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
                MessageBox.Show("Estoque atualizado com sucesso");
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            var ctx = new ERPDBModelContainer();
            Update(sender, e);
            ComboBoxExibir.ItemsSource = (ctx.CategoriaSet.ToList().Count > 0) ? ctx.CategoriaSet.ToList() : null;
        }

        private void DataGridProduto_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) {
            if (e.EditAction == DataGridEditAction.Commit) {
                var context = new ERPDBModelContainer();
                var produto = (Produto)e.Row.Item;
                var original = context.ProdutoSet.Find(produto.Id);
                if (original != null) {
                    context.Entry(original).CurrentValues.SetValues(produto);
                    context.SaveChanges();
                }
                Update(sender, null);
            }
        }

        private void ComboBoxExibir_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems[0].GetType() != typeof(ComboBoxItem)) {
                DataGridProduto.ItemsSource = ((Categoria)e.AddedItems[0]).Produto;
            } else if (e.RemovedItems.Count > 0) {
                Update(sender, null);
            }
        }
    }
}
