using ModelLib;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace View.SubWindows {
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window {
        public LogWindow() {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e) {
            RichTextBoxLog.Document.Blocks.Clear();
            var str = "";
            foreach (var s in File.ReadLines("log.ntn")) {
                str += "\n" +Crypto.DecryptStringAES(s, "capitu");
            }
            RichTextBoxLog.Document.Blocks.Add(new Paragraph(new Run(str)));
        }
        private void Window_GotFocus(object sender, RoutedEventArgs e) {
            Window_ContentRendered(sender, e);
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e) {
            Window_ContentRendered(sender,null);
        }

    }
}
