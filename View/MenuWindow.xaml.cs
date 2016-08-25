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
using View.UserControls;
using System.Data.Entity.Validation;

namespace View {
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window {

        public MenuWindow() {
            InitializeComponent();
            this.Title = Globals.Instance.NomeEmpresa;
            /*
            var c = new Categoria { Id = 0, Nome = "Teste" };
            var p = new Produto { Nome = "Teste 1", Id = 0, DisponivelLojaVirtual = false, PrecoCusto=5.0, PrecoPrazo=7, PrecoVista=6, Quantidade=30 };
            var l = new List<Produto>();
            l.Add(p);
            c.Produto = l;
            p.Categoria = c;
            var context = new ERPDBModelContainer();
            context.ProdutoSet.Add(p);
            context.SaveChanges();
            var prods = from pr in context.ProdutoSet
                        select pr;
            foreach (Produto produto in prods)
            {
                Console.WriteLine(p.Nome);
            }
            */



        }

        private void VendasButtonClick(object sender, RoutedEventArgs e) {
            this.ControlGrid.Children.Clear();
            this.ControlGrid.Children.Add(new VendaView());
        }

        private void ProdutosButtonClick(object sender, RoutedEventArgs e) {
            this.ControlGrid.Children.Clear();
            this.ControlGrid.Children.Add(new ProdutosView());
        }

        private void MenuViewWindow_SizeChanged(object sender, SizeChangedEventArgs e) {
            if (e.HeightChanged){
                double prev = e.PreviousSize.Height;
                if (e.PreviousSize.Height == 0) prev = 600;
                double diff = prev - e.NewSize.Height;
                this.UpperGrid.Height = (this.UpperGrid.Height - diff < 0) ? 100: this.UpperGrid.Height - diff ;
            }
        }

        private void UsuariosButtonClick(object sender, RoutedEventArgs e) {
            this.ControlGrid.Children.Clear();
            this.ControlGrid.Children.Add(new UsuarioView());
        }

        private void FornecedoresButtonClick(object sender, RoutedEventArgs e) {
            this.ControlGrid.Children.Clear();
            this.ControlGrid.Children.Add(new FornecedoresView());
        }

        private void CaixasButtonClick(object sender, RoutedEventArgs e) {
            this.ControlGrid.Children.Clear();
            this.ControlGrid.Children.Add(new CaixasView());
        }
    }

}
