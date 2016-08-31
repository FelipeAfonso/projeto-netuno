using ModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AdicionarProdutoWindow.xaml
    /// </summary>
    public partial class AdicionarProdutoWindow : Window {
        public AdicionarProdutoWindow() {
            InitializeComponent();
        }

        private void buttonLimpar_Click(object sender, RoutedEventArgs e) {
            foreach (TextBox t in FormGrid.Children.OfType<TextBox>().ToList()) {
                t.Clear();
                if (t.GetType() == typeof(CurrencyTextBoxControl.CurrencyTextBox)) t.Text = "$0.00";
            }
            textBoxEstoque.Text = "0";
            checkBoxEstoque.IsChecked = true;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e) {
            Produto produto;
            var context = new ERPDBModelContainer();
            try {
                produto = new Produto() {
                    Codigo = Int32.Parse(textBoxCodigo.Text),
                    Nome = textBoxNome.Text,
                    PrecoCusto = Double.Parse(textBoxPrecoCusto.Text.Substring(1), NumberStyles.Currency, CultureInfo.InvariantCulture),
                    PrecoVista = Double.Parse(textBoxPrecoVista.Text.Substring(1), NumberStyles.Currency, CultureInfo.InvariantCulture),
                    //Categoria = textBoxCategoria.Text,
                    Descricao = textBoxDescricao.Text
                };//Double.Parse(textBoxPrecoCusto.Text.Substring(1), NumberStyles.Currency, CultureInfo.InvariantCulture)
            } catch {
                MessageBox.Show("Erro ao cadastrar, certifique-se de que todos os campos obrigatórios foram preenchidos corretamente", "Erro ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
                produto = null;
            }
            try {
                if (produto != null && textBoxPrecoPrazo.IsEnabled && textBoxPrecoPrazo.Text != "$0.00") produto.PrecoPrazo = Double.Parse(textBoxPrecoPrazo.Text.Substring(1), NumberStyles.Currency, CultureInfo.InvariantCulture);
            } catch {
                MessageBox.Show("Erro ao cadastrar Preço a Prazo, certifique-se de que o valor inserido é maior que 0", "Erro ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
                produto = null;
            }
            try {
                if (produto != null && textBoxEstoque.IsEnabled && textBoxEstoque.Text != "" && Double.Parse(textBoxEstoque.Text) >= 0) produto.Quantidade = Double.Parse(textBoxEstoque.Text); else throw new Exception();
            } catch { MessageBox.Show("Erro de Estoque, certifique-se de que o valor inserido é maior que 0", "Erro ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error); produto = null; }
            if (produto != null) {
                var query = context.ProdutoSet.Where(p => p.Codigo == produto.Codigo).ToList();
                if (query.Count == 0) {
                    context.ProdutoSet.Add(produto);
                    context.SaveChanges();
                    if (MessageBox.Show("Produto Cadastrado com Sucesso!\nLimpar informações e cadastrar outro produto?", "Sucesso!", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                        buttonLimpar_Click(sender, e);
                    } else {
                        this.Close();
                    }
                } else {
                    MessageBox.Show("Código já existente", "Erro ao Cadastrar Produto", MessageBoxButton.OK, MessageBoxImage.Error);
                    produto = null;
                }
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e) {
            textBoxEstoque.IsEnabled = (bool)((CheckBox)sender).IsChecked;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e) {
            textBoxEstoque.IsEnabled = (bool)((CheckBox)sender).IsChecked;
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !Controller.IsTextAllowed(e.Text);
        }

        private void checkBox_Checked_1(object sender, RoutedEventArgs e) {
            textBoxPrecoPrazo.IsEnabled = (bool)((CheckBox)sender).IsChecked;
        }

        private void checkBoxPreco_Unchecked(object sender, RoutedEventArgs e) {
            textBoxPrecoPrazo.IsEnabled = (bool)((CheckBox)sender).IsChecked;
        }
    }
}
