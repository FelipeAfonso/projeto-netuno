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
    /// Interaction logic for UsuarioView.xaml
    /// </summary>
    public partial class UsuarioView : UserControl {

        FuncionarioManagerWindow p;

        public UsuarioView() {
            InitializeComponent();
            if (Controller.LoggedUser is Administrador
                || Controller.LoggedUser.Permissao.FirstOrDefault(o => o.Descricao == Controller.Permissoes["GerenciarFuncionarios"].Descricao) != null) {
                ButtonAdicionarFuncionario.IsEnabled = true;
                ButtonDeletar.IsEnabled = true;
            }
            Update(null, null);
        }

        private void ButtonAdicionarCliente_Click(object sender, System.Windows.RoutedEventArgs e) {
            // TODO: Add event handler implementation here.
        }

        private void ButtonEditar_Click(object sender, System.Windows.RoutedEventArgs e) {
            // TODO: Add event handler implementation here.
        }

        private void ButtonDeletar_Click(object sender, System.Windows.RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            foreach (UsuarioAdapter usuario in DataGridUsuarios.SelectedItems) {
                var u = context.UsuarioSet.Single(o => o.Id == usuario.Id);
                context.UsuarioSet.Remove(u);
                Controller.Log("Deletou o Usuario: " + u.Nome);
            }
            context.SaveChanges();
            Update(sender, e);
        }

        private void ButtonAdicionarFuncionario_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (p == null) {
                p = new FuncionarioManagerWindow();
                p.Closed += (a, b) => p = null;
                p.buttonAdd.Click += Update;
                p.Show();
            } else if (p.IsVisible) p.Focus();
            else p.Show();
        }

        private void Update(object sender, RoutedEventArgs e) {
            var context = new ERPDBModelContainer();
            var l = new List<UsuarioAdapter>();
            foreach (Usuario u in context.UsuarioSet.OfType<Funcionario>().ToList()) {
                if (!(u is Administrador)) { l.Add(new UsuarioAdapter(u)); }
            }
            DataGridUsuarios.ItemsSource = (l.Count > 0) ? l : null;
        }
    }
}
