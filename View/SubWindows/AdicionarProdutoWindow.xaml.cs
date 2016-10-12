using Microsoft.Win32;
using ModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
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

        private bool edit_mode = false;
        private Produto produto_edit;

        public AdicionarProdutoWindow() {
            InitializeComponent();
        }

        public AdicionarProdutoWindow(Produto p) { edit_mode = true; InitializeComponent(); produto_edit = p; }

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
            try {
                if (produto != null && AutoCompleteBoxCategoria.Text != "") {
                    if (context.CategoriaSet.SingleOrDefault(o => o.Nome == AutoCompleteBoxCategoria.Text) != null) {
                        produto.Categoria = AutoCompleteBoxCategoria.SelectedItem as Categoria;
                    } else {
                        var c = new Categoria() { Nome = AutoCompleteBoxCategoria.Text, Produto = new List<Produto>() };
                        c.Produto.Add(produto);
                        context.CategoriaSet.Add(c);
                    }
                }
                if (produto != null && comboBoxFornecedores.SelectedItem != null) {
                    produto.Fornecedor = context.FornecedorSet.SingleOrDefault(o => o.Nome == (string)comboBoxFornecedores.SelectedItem);
                }

            } catch { produto = null; }
            try {
                if ((bool)checkBoxOnline.IsChecked) { produto.DisponivelLojaVirtual = true; }
            } catch { }
            if (edit_mode) {
                var original = context.ProdutoSet.First(o => o.Id == produto_edit.Id);
                original.Nome = produto.Nome;
                original.Codigo = produto.Codigo;
                original.Categoria = produto.Categoria;
                original.Descricao = produto.Descricao;
                original.Fornecedor = produto.Fornecedor;
                original.PrecoCusto = produto.PrecoCusto;
                original.PrecoPrazo = produto.PrecoPrazo;
                original.PrecoVista = produto.PrecoVista;
                original.Quantidade = produto.Quantidade;
                context.SaveChanges();
                MessageBox.Show("Produto alterado com Sucesso!", "Sucesso!");
                this.Close();
            } else if (produto != null) {
                var query = context.ProdutoSet.Where(p => p.Codigo == produto.Codigo).ToList();
                if (query.Count == 0) {
                    Controller.Log("Adicionou o Produto: " + produto.Nome + " com o código: " + produto.Codigo);
                    context.ProdutoSet.Add(produto);
                    context.SaveChanges();
                    if (MessageBox.Show("Produto Cadastrado com Sucesso!\nLimpar informações e cadastrar outro produto?", "Sucesso!", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                        buttonLimpar_Click(sender, e);
                        Window_ContentRendered(sender, e);
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

        private void Window_ContentRendered(object sender, EventArgs e) {
            AutoCompleteBoxCategoria.ItemFilter += (s, o) => (o as Categoria).Nome.ToString().Contains(s);
            var ctx = new ERPDBModelContainer();
            AutoCompleteBoxCategoria.ItemsSource = ctx.CategoriaSet.ToList();
            var l = new List<String>();
            foreach (Fornecedor f in ctx.FornecedorSet.ToList()) {
                l.Add(f.Nome);
            }
            comboBoxFornecedores.ItemsSource = l;
            ctx.Dispose();
            if (edit_mode) {
                LabelTitle.Content = "Editar Produto " + produto_edit.Nome;
                textBoxCodigo.Text = produto_edit.Codigo.ToString();
                textBoxNome.Text = produto_edit.Nome;
                textBoxPrecoCusto.Text = produto_edit.PrecoCusto.ToString("0.00", CultureInfo.InvariantCulture);
                textBoxPrecoVista.Text = produto_edit.PrecoVista.ToString("0.00", CultureInfo.InvariantCulture);
                textBoxPrecoPrazo.Text = (produto_edit.PrecoPrazo != null) ? ((double)produto_edit.PrecoPrazo).ToString("0.00", CultureInfo.InvariantCulture) : "0";
                textBoxEstoque.Text = produto_edit.Quantidade.ToString();
                textBoxDescricao.Text = produto_edit.Descricao;
                AutoCompleteBoxCategoria.Text = produto_edit.Nome;
                comboBoxFornecedores.SelectedItem = (produto_edit.Fornecedor != null) ? produto_edit.Fornecedor.Nome : "";
            }
        }


        private byte[] imgToByteArray(BitmapImage image) {
            JpegBitmapEncoder enc = new JpegBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(image));
            using (var ms = new MemoryStream()) {
                enc.Save(ms);
                return ms.ToArray();
            }
        }
    }
}
