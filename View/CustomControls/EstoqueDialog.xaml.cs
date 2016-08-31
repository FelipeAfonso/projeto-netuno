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

namespace View.CustomControls {
    /// <summary>
    /// Interaction logic for EstoqueDialog.xaml
    /// </summary>
    public partial class EstoqueDialog : Window {
        public EstoqueDialog() {
            InitializeComponent();
        }

        private void buttonLancar_Click(object sender, RoutedEventArgs e) {
            var q = true;

            this.DialogResult = q;
        }

        public KeyValuePair<int, Produto> getProduto {
            get {
                return new KeyValuePair<int,Produto>(Int32.Parse(textBoxQuantidade.Text), (Produto)((ComboBoxItem)ComboBoxProduto.SelectedItem).Tag );
            }
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

        private void Window_ContentRendered(object sender, EventArgs e) {
            var ctx = new ERPDBModelContainer();
            var l = new List<ComboBoxItem>();
            foreach(Produto p in ctx.ProdutoSet.ToList()){
                var c = new ComboBoxItem(){ Content = p.Nome, Tag = p };
                l.Add(c);
            }
            ComboBoxProduto.ItemsSource = l;
        }
    }
}
