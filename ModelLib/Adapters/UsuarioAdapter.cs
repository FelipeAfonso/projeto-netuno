using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Adapters {
    public class UsuarioAdapter {

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Nascimento { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public virtual Endereco Endereco { get; set; }

        public UsuarioAdapter(Usuario u) {
            Id = u.Id;
            Cpf = u.Cpf;
            Email = u.Email;
            Nascimento = u.Nascimento;
            Nome = u.Nome;
            Rg = u.Rg;
            Senha = u.Senha;
            Sexo = u.Sexo;
            Telefone = u.Telefone;
            Celular = u.Celular;
        }

        public string EnderecoFormated { get { try { return Endereco.Cidade + ", " + Endereco.Estado + " - " + Endereco.Logradouro + ". " + Endereco.Bairro; } catch { return "Endereço Incompleto"; } } }
    }
}
