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
using View.CustomControls;
using System.Data.Entity.Validation;
using System.Threading;

namespace View {
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window {

        public MenuWindow() {
            InitializeComponent();
            this.Title = Globals.Instance.NomeEmpresa;
            foreach (Button b in GridButtons.Children) b.IsEnabled = false;
            var t = new Thread(LoginThread);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
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
            if (e.HeightChanged) {
                double prev = e.PreviousSize.Height;
                if (e.PreviousSize.Height == 0) prev = 600;
                double diff = prev - e.NewSize.Height;
                this.UpperGrid.Height = (this.UpperGrid.Height - diff < 0) ? 100 : this.UpperGrid.Height - diff;
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

        private void MenuViewWindow_ContentRendered(object sender, EventArgs e) {

        }

        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void LoginThread() {
            var context = new ERPDBModelContainer();
            //Liberar apenas para teste
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE UsuarioSet_Administrador");
            var query = context.UsuarioSet.OfType<Administrador>().ToList();
            if (Controller.LoggedUser == null) {
                if (query.Count == 0) {
                    Application.Current.Dispatcher.Invoke((Action)(() => {
                        var dialog = new CreateAdminDialog();
                        foreach (Button b in GridButtons.Children) b.IsEnabled = true;
                        LoadingGrid.Visibility = Visibility.Collapsed;
                        Menu.IsEnabled = true;
                        if (dialog.ShowDialog() == true) {
                            context.UsuarioSet.Add(dialog.getAdmin);
                            context.SaveChanges();
                            Controller.LoggedUser = dialog.getAdmin;
                        }
                    }));
                }
                var valid = false;
                if (Controller.LoggedUser == null) {
                    Application.Current.Dispatcher.Invoke((Action)(() => {
                        foreach (Button b in GridButtons.Children) b.IsEnabled = true;
                        LoadingGrid.Visibility = Visibility.Collapsed;
                        Menu.IsEnabled = true;
                    }));
                    while (!valid) {
                        Application.Current.Dispatcher.Invoke((Action)(() => {
                            var dialog = new LoginDialog();
                            if (dialog.ShowDialog() == true) {
                                var users = context.UsuarioSet.Where(u => u.Nome.ToLower() == dialog.getFuncionario.Nome.ToLower()).ToList();
                                foreach (Funcionario f in users) {
                                    if (f.Senha == dialog.getFuncionario.Senha) { Controller.LoggedUser = f; valid = true; }
                                }
                            }
                            if (Controller.LoggedUser == null) MessageBox.Show("Usuário Inválido", "Erro ao acessar");
                        }));
                    }

                }
            } else {
                Application.Current.Dispatcher.Invoke((Action)(() => {
                    foreach (Button b in GridButtons.Children) b.IsEnabled = true;
                    LoadingGrid.Visibility = Visibility.Collapsed;
                    Menu.IsEnabled = true;
                }));
            }

        }

    }

}
