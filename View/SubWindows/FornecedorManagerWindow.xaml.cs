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
    /// <summary>
    /// Interaction logic for FornecedorManagerWindow.xaml
    /// </summary>
    public partial class FornecedorManagerWindow : Window {
        public FornecedorManagerWindow() {
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
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e) {
            Fornecedor fornecedor = null;
            var ctx = new ERPDBModelContainer();
            try {
                if (textBoxNome.Text == "") throw new Exception();
                fornecedor = new Fornecedor() { Nome = textBoxNome.Text };
            }catch {
                MessageBox.Show("Erro ao cadastrar, certifique-se de que todos os campos obrigatórios foram preenchidos corretamente", "Erro ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
                fornecedor = null;
            }
            if (textBoxTelefone.Text != "") fornecedor.Telefone = textBoxTelefone.Text;
            if (textBoxCelular.Text != "") fornecedor.Celular = textBoxCelular.Text;
            if (textBoxCNPJ.Text != "") fornecedor.CNPJ = textBoxCNPJ.Text;
            Endereco endereco= null;
            if (textBoxEndereco.Text != "") { if (endereco==null) endereco = new Endereco(); endereco.Logradouro = textBoxEndereco.Text; }
            if (textBoxBairro.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.Bairro = textBoxBairro.Text; }
            if (textBoxCidade.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.Cidade = textBoxCidade.Text; }
            if (textBoxEstado.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.Estado = textBoxEstado.Text; }
            if (textBoxCep.Text != "") { if (endereco == null) endereco = new Endereco(); endereco.CEP = textBoxCep.Text; }
            if (endereco != null) fornecedor.Endereco = endereco;
            if (textBoxEmail.Text != "") fornecedor.Email = textBoxEmail.Text;
            if (textBoxObservacoes.Text != "") fornecedor.Observacoes = textBoxObservacoes.Text;

            if(fornecedor != null) {
                var query = ctx.FornecedorSet.Where(f => f.Nome == fornecedor.Nome).ToList();
                if (query.Count == 0) {
                    ctx.FornecedorSet.Add(fornecedor);
                    ctx.SaveChanges();
                    if (MessageBox.Show("Produto Cadastrado com Sucesso!\nLimpar informações e cadastrar outro produto?", "Sucesso!", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                        buttonLimpar_Click(sender, e);
                    } else {
                        this.Close();
                    }
                }else {
                    if (MessageBox.Show("Nome já existente, deseja cadastrar mesmo assim?", "Erro", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                        ctx.FornecedorSet.Add(fornecedor);
                        ctx.SaveChanges();
                        if (MessageBox.Show("Produto Cadastrado com Sucesso!\nLimpar informações e cadastrar outro produto?", "Sucesso!", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                            buttonLimpar_Click(sender, e);
                        } else {
                            this.Close();
                        }
                    } else {
                        this.Close();
                    }
                }
            }
        }
    }
}
