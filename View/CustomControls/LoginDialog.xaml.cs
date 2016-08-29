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
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window {
        public LoginDialog() {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, RoutedEventArgs e) {
            var q = true;
            String error = "";
            if (textBoxNome.Text == null || textBoxNome.Text == "") { q = false; error += " - Por favor, insira o Nome\n"; }
            if (textBoxSenha.Password == null || textBoxSenha.Password == "") { q = false; error += " - Insira a Senha\n"; }
            if (q) this.DialogResult = q;
            else MessageBox.Show(error, "Erro ao fazer login", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public Funcionario getFuncionario {
            get {
                return new Funcionario() { Nome = textBoxNome.Text, Senha = Controller.getMD5(textBoxSenha.Password) };
            }
        }

        private void buttonShutdown_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
