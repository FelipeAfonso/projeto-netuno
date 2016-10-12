using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Adapters {
    public class VendaAdapter {
        public int Id { get; set; }
        public System.DateTime Data { get; set; }
        public double Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual ICollection<ProdutoVendaItem> ProdutoVendaItem { get; set; }

        public VendaAdapter(Venda v) {
            Id = v.Id;
            Data = v.Data;
            Total = v.Total;
            Cliente = v.Cliente;
            Funcionario = v.Funcionario;
            ProdutoVendaItem = v.ProdutoVendaItem;
        }

        public String TotalFormated { get { return (Total > 0) ? String.Format("{0:C}", Total) : ""; } }

        public String FuncionarioNome { get { return Funcionario.Nome; } }

        public String ClienteNome { get { return (Cliente != null) ? Cliente.Nome : ""; } }

        public String Itens {
            get {
                using (var ctx = new ERPDBModelContainer()) {
                    var s = "";
                    var l = ctx.ProdutoVendaItemSet.Where(o => o.Venda.Id == this.Id).ToList();
                    foreach (ProdutoVendaItem pvi in l) {
                        s += (pvi.Produto != null) ? pvi.Quantidade + " - " + pvi.Produto.Nome + "\n" : "Produto Removido\n";
                    }
                    s = s.Remove(s.Length - 1);
                    return s;
                }
            }
        }
    }
}
