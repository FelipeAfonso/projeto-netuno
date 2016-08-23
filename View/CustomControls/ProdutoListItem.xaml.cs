using ModelLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace View.CustomControls {
    /// <summary>
    /// Interaction logic for ProdutoListItem.xaml
    /// </summary>
    public partial class ProdutoListItem : UserControl {

        private Produto p;
        int qtd;

        public ProdutoListItem(Produto p, int qtd) {
            InitializeComponent();
            this.p = p;
            this.qtd = qtd;
        }

        private void ProdutoListItemControl_Initialized(object sender, EventArgs e) {
            using(var ms = new MemoryStream()) {
                image.Source = Convert(new Bitmap(ms));
            }
            labelQuantidade.Content = qtd;
            textBlockNome.Text = p.Nome;
            textBlockPreco.Text = "R$ " + p.PrecoVista.ToString("{0:0,0.00}");
        }

        public BitmapSource Convert(System.Drawing.Bitmap bitmap) {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height, 96, 96, PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }
    }
}
