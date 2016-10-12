using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Adapters {
    public class FornecedorAdapter {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Observacoes { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
        public virtual Endereco Endereco { get; set; }

        public FornecedorAdapter(Fornecedor f) {
            Id = f.Id;
            Nome = f.Nome;
            Telefone = f.Telefone;
            Celular = f.Celular;
            Email = f.Email;
            Observacoes = f.Observacoes;
            Produto = f.Produto;
            Endereco = f.Endereco;
        }

        public string EnderecoFormated { get { try { return Endereco.Cidade + ", " + Endereco.Estado + " - " + Endereco.Logradouro + ". " + Endereco.Bairro; } catch { return "Endereço Incompleto"; } } }
    }
}
