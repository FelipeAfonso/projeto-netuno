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
            DataGridProduto.ItemsSource = context.ProdutoSet.ToList();
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
            // TODO: Add event handler implementation here.
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            Update(sender, e);
        }

        private void DataGridProduto_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) {
            if (e.EditAction == DataGridEditAction.Commit) {
                var context = new ERPDBModelContainer();
                var produto = (Produto)e.Row.Item;
                var original = context.ProdutoSet.Find(produto.Id);
                if(original != null) {
                    context.Entry(original).CurrentValues.SetValues(produto);
                    context.SaveChanges();
                }
                Update(sender, null);
            }
        }
    }
}
