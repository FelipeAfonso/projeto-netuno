using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel {
    public static class MainWindowViewModel {

        public static void Load(Window current, Window target) {

            //Load logic here

            target.Show();

            current.Close();
            
        }

    }
}
