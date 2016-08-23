using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib {
    public class Globals {
        private static Globals _Instance;

        public static Globals Instance {
            get {
                if (_Instance == null)
                    _Instance = new Globals();
                return _Instance;
            }
        }

        private Globals() { 
            //NomeEmpresa = "Teste"
        }

        private string _nomeEmpresa;
        public string NomeEmpresa {
            get {
                if (_nomeEmpresa != null) return "Undertow - " + _nomeEmpresa;
                else return "Undertow";
            }
            set {
                _nomeEmpresa = value;
            }
        }

    }
}
