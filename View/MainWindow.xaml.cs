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
using System.Globalization;
using System.Collections;
using System.Resources;

namespace View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            LoadData();
        }

        private void LoadData() {

            Controller.Permissoes.Add("LançarVendas", new Permissao() { Descricao = PermissoesResource.LancarCompras });
            Controller.Permissoes.Add("EditarVendas", new Permissao() { Descricao = PermissoesResource.EditarCompras });
            Controller.Permissoes.Add("GerenciarEstoque", new Permissao() { Descricao = PermissoesResource.GerenciarEstoque });
            Controller.Permissoes.Add("GerenciarProdutos", new Permissao() { Descricao = PermissoesResource.GerenciarProdutos });
            Controller.Permissoes.Add("GerenciarFornecedores", new Permissao() { Descricao = PermissoesResource.GerenciarFornecedores});

            new MenuWindow().Show();
            this.Close();
        }
    }
}
