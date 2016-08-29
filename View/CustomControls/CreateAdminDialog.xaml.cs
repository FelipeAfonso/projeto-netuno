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

using ModelLib;

namespace View.CustomControls {
    /// <summary>
    /// Interaction logic for CreateAdminDialog.xaml
    /// </summary>
    public partial class CreateAdminDialog : Window {
        public CreateAdminDialog() {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, RoutedEventArgs e) {
            var q = true;
            String error = "";

            if (textBoxNome.Text == null || textBoxNome.Text == "") { q = false; error += " - O Campo Nome deve ser preenchido\n"; }
            if (textBoxEmail.Text == null || textBoxEmail.Text == "") {
                q = false; error += " - O Campo Email deve ser preenchido\n";
            } else if (!Controller.IsValidMailAddress(textBoxEmail.Text)) {
                q = false; error += " - Email inválido\n";
            }
            if (textBoxPassword.Password == null || textBoxPassword.Password == "" || textBoxPassword.Password.Count() < 6) { q = false; error += " - O Campo Senha deve ser preenchido e haver mais que 6 caracteres\n"; }
            if (q)
                this.DialogResult = q;
            else
                MessageBox.Show(error, "Erro ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public Administrador getAdmin {
            get {
                return new Administrador() {
                    Nome = textBoxNome.Text, Email = textBoxEmail.Text, Senha = Controller.getMD5(textBoxPassword.Password)
                };
            }
        }

        private void buttonShutdown_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
