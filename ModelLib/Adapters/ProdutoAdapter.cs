using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Adapters {
    public class ProdutoAdapter {

        public int Id { get; set; }
        public string Nome { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVista { get; set; }
        public Nullable<double> PrecoPrazo { get; set; }
        public Nullable<double> Quantidade { get; set; }
        public Nullable<bool> DisponivelLojaVirtual { get; set; }
        public string Descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public Nullable<byte> Imagem { get; set; }
        public int Codigo { get; set; }

        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }
        //public virtual ProdutoVendaItem ProdutoVendaItem { get; set; }

        public String FornecedorNome { get { return (this.Fornecedor !=null) ? this.Fornecedor.Nome : ""; } }
        public String CategoriaNome { get { return (this.Categoria != null) ? this.Categoria.Nome : ""; } }
        public String PrecoCustoFormated { get { return (PrecoCusto > 0) ? String.Format("{0:C}", PrecoCusto) : ""; } }
        public String PrecoPrazoFormated { get { return (PrecoPrazo > 0) ? String.Format("{0:C}", PrecoPrazo) : ""; } }

        public ProdutoAdapter(Produto p) {
            Id = p.Id;
            Nome = p.Nome;
            PrecoCusto = p.PrecoCusto;
            PrecoVista = p.PrecoVista;
            PrecoPrazo = p.PrecoPrazo;
            Quantidade = p.Quantidade;
            DisponivelLojaVirtual = p.DisponivelLojaVirtual;
            Descricao = p.Descricao;
            UnidadeMedida = p.UnidadeMedida;
            Imagem = p.Imagem;
            Codigo = p.Codigo;
            Categoria = p.Categoria;
            Fornecedor = p.Fornecedor;
            //ProdutoVendaItem = p.ProdutoVendaItem;
        }
    }
}
