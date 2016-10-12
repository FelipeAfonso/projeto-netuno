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
using View.SubWindows;

namespace View.UserControls {
    /// <summary>
    /// Interaction logic for FornecedoresView.xaml
    /// </summary>
    public partial class FornecedoresView : UserControl {

        private FornecedorManagerWindow p;

        public FornecedoresView() {
            InitializeComponent();

            if (Controller.LoggedUser is Administrador
                || Controller.LoggedUser.Permissao.FirstOrDefault(o => o.Descricao == Controller.Permissoes["GerenciarFornecedores"].Descricao) != null) {
                ButtonAdicionar.IsEnabled = true;
                ButtonDeletar.IsEnabled = true;
            }
            Update(null, null);
        }

        private void ButtonEditar_Click(object sender, System.Windows.RoutedEventArgs e) {
            // TODO: Add event handler implementation here.
        }

        private void ButtonAdicionar_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (p == null) {
                p = new FornecedorManagerWindow();
                p.Closed += (a, b) => p = null;
                p.buttonAdd.Click += Update;
                p.Show();
            } else if (p.IsVisible) p.Focus();
            else p.Show();
        }

        private void ButtonDeletar_Click(object sender, System.Windows.RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            foreach (FornecedorAdapter fornecedor in DataGridFornecedores.SelectedItems) {
                var p = context.FornecedorSet.Single(o => o.Id == fornecedor.Id);
                p.Produto.Clear();
                Controller.Log("Deletou o Fornecedor: " + fornecedor.Nome);
                context.FornecedorSet.Remove(p);
            }
            context.SaveChanges();
            Update(sender, e);
        }

        private void Update(object sender, RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            var l = new List<FornecedorAdapter>();
            foreach (var f in context.FornecedorSet.ToList()) {
                l.Add(new FornecedorAdapter(f));
            }
            DataGridFornecedores.ItemsSource = (l.Count > 0) ? l : null;
        }

        private void DataGridFornecedores_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) {
            if (e.EditAction == DataGridEditAction.Commit) {
                var context = new ERPDBModelContainer();
                var fornecedor = (Fornecedor)e.Row.Item;
                var original = context.FornecedorSet.Single(o => o.Id == fornecedor.Id);
                if (original != null) {
                    context.Entry(original).CurrentValues.SetValues(fornecedor);
                    context.SaveChanges();
                }
                Update(sender, null);
            }
        }
    }
}
