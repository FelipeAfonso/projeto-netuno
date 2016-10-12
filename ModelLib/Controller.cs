using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace ModelLib {
    public static class Controller {

        public static Dictionary<string, Permissao> Permissoes = new Dictionary<string, Permissao>();

        public static Funcionario LoggedUser;// = new Administrador() { Id=1, Nome = "Teste", Senha = "", Email = "asd@asd.com", Venda= new List<Venda>() };

        public static List<object> PostJsonProduto(List<Produto> l) {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8094/WebService/Products");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
                var temp = new List<dynamic>();
                foreach (Produto p in l) {
                    if (p.Categoria != null)
                        temp.Add(new {
                            Id = p.Id, Nome = p.Nome, PrecoCusto = p.PrecoCusto, PrecoVista = p.PrecoVista,
                            PrecoPrazo = p.PrecoPrazo, Quantidade = p.Quantidade, DisponivelLojaVirtual = p.DisponivelLojaVirtual,
                            Descricao = p.Descricao, UnidadeMedida = p.UnidadeMedida, Imagem = p.Imagem, Codigo = p.Codigo,
                            Fornecedor =p.Fornecedor, ProdutoVendaItem = p.ProdutoVendaItem,
                            Categoria = new { Id = p.Categoria.Id, Nome = p.Categoria.Nome }
                        });
                    else
                        temp.Add(new {
                            Id = p.Id, Nome = p.Nome, PrecoCusto = p.PrecoCusto, PrecoVista = p.PrecoVista,
                            PrecoPrazo = p.PrecoPrazo, Quantidade = p.Quantidade, DisponivelLojaVirtual = p.DisponivelLojaVirtual,
                            Descricao = p.Descricao, UnidadeMedida = p.UnidadeMedida, Imagem = p.Imagem, Codigo = p.Codigo,
                            Fornecedor = p.Fornecedor, ProdutoVendaItem = p.ProdutoVendaItem, Categoria = p.Categoria
                        });
                }

                string json = new JavaScriptSerializer().Serialize(temp);
                //string json = new JavaScriptSerializer().Serialize(l);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
                    var result = streamReader.ReadToEnd();
                    return new JavaScriptSerializer().Deserialize(result, typeof(List<object>)) as List<object>;
                }
            } catch {
                return null;
            }
        }

        public static string getMD5(String i) {
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] input = System.Text.Encoding.ASCII.GetBytes(i);
            byte[] hash = md5.ComputeHash(input);
            var sb = new StringBuilder();
            for (int x = 0; x < hash.Length; x++) { sb.Append(hash[x].ToString("X2")); }
            return sb.ToString();
        }

        public static bool IsValidMailAddress(string mailAddress) {
            return System.Text.RegularExpressions.Regex.IsMatch(mailAddress, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public static bool IsTextAllowed(string text) {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        public static void Log(string action) {
            using (var w = File.AppendText("log.ntn")) {
                var s = "";
                s += "\r\nUsuario " + Controller.LoggedUser.Nome + ": as ";
                s+= DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + "\n";
                //w.WriteLine("  :");
                s+= "  : "+ action;
                s+="\n-------------------------------";
                w.WriteLine(Crypto.EncryptStringAES(s, "capitu"));
                //w.WriteLine(s);
            }
        }

    }
}
