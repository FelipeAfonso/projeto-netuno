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

namespace View.SubWindows {
    public partial class FuncionarioManagerWindow : Window {
        public FuncionarioManagerWindow() {
            InitializeComponent();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !Controller.IsTextAllowed(e.Text);
        }

        private void buttonLimpar_Click(object sender, RoutedEventArgs e) {
            foreach (TextBox t in FormGrid.Children.OfType<TextBox>().ToList()) {
                t.Clear();
                if (t.GetType() == typeof(CurrencyTextBoxControl.CurrencyTextBox)) t.Text = "$0.00";
            }
            textBoxPassword.Clear();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e) {
            Funcionario funcionario = null;
            var ctx = new ERPDBModelContainer();
            try {
                if (textBoxNome.Text == "") throw new Exception();
                funcionario = new Funcionario() { Nome = textBoxNome.Text, Senha = Controller.getMD5(textBoxPassword.Password) };
                var permissoes = new List<Permissao>();
                foreach (CheckBox cb in ListBoxPermissoes.Items) {
                    if ((bool)cb.IsChecked) permissoes.Add((Permissao)cb.Tag);
                }
                funcionario.Permissao = permissoes;
            } catch {
                MessageBox.Show("Erro ao cadastrar, certifique-se de que todos os campos obrigatórios foram preenchidos corretamente", "Erro ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
                funcionario = null;
            }
            if (textBoxTelefone.Text != "") funcionario.Telefone = textBoxTelefone.Text;
            if (textBoxCelular.Text != "") funcionario.Celular = textBoxCelular.Text;
            if (textBoxCPF.Text != "") funcionario.Cpf = textBoxCPF.Text;
            Endereco endereco = null;
            if (textBoxEndereco.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.Logradouro = textBoxEndereco.Text; }
            if (textBoxBairro.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.Bairro = textBoxBairro.Text; }
            if (textBoxCidade.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.Cidade = textBoxCidade.Text; }
            if (textBoxEstado.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.Estado = textBoxEstado.Text; }
            if (textBoxCep.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.CEP = textBoxCep.Text; }
            if (endereco != null) {
                endereco.Usuario = funcionario;
            }
            if (textBoxEmail.Text != "") funcionario.Email = textBoxEmail.Text;

            if (funcionario != null) {
                var query = ctx.UsuarioSet.OfType<Funcionario>().Where(f => f.Nome == funcionario.Nome).ToList();
                if (query.Count == 0) {
                    //ctx.UsuarioSet.Add(funcionario);
                    //ctx.UsuarioSet.Attach(endereco.Usuario);
                    if (endereco != null) ctx.EnderecoSet.Add(endereco);
                    else ctx.UsuarioSet.Add(funcionario);
                    ctx.SaveChanges();
                    var s = "";
                    foreach(Permissao p in funcionario.Permissao) {
                        s += "\n - " + p.Descricao;
                    }
                    Controller.Log("Adicionou o Funcionário: " + funcionario.Nome + " com as seguintes permissões:" + s);
                    if (MessageBox.Show("Funcionário Cadastrado com Sucesso!\nLimpar informações e cadastrar outro Funcionário?", "Sucesso!", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                        buttonLimpar_Click(sender, e);
                    } else {
                        this.Close();
                    }
                } else {
                    MessageBox.Show("Nome já existente", "Erro");
                }
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e) {
            foreach (var h in Controller.Permissoes) {
                ListBoxPermissoes.Items.Add(new CheckBox() { Content = h.Key, Tag = h.Value });
            }
        }
    }
}
