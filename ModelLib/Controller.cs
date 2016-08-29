using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelLib;

namespace ModelLib {
    public static class Controller {

        public static Funcionario LoggedUser = new Administrador() { Nome = "Teste", Senha = "", Email = "asd@asd.com" };

        public static Loja getLojaSingleton(ERPDBModelContainer ctx) {
            if (ctx.LojaSet.ToList().Count == 0) {
                var e = new Estoque() { Custo = 0, Valor = 0 };
                var c = new Caixa() { Valor=0 };
                var cl = new List<Caixa>();
                cl.Add(c);
                var l = new Loja() { Caixa = cl, Estoque = e };
                e.Loja = l; c.Loja = l;
                ctx.LojaSet.Add(l);
                ctx.SaveChanges();
                return l;
            }else {
                return ctx.LojaSet.First();
            }
        }
        public static void setLojaSingleton(ERPDBModelContainer ctx, Loja newLoja) {
            var original = ctx.LojaSet.First();
            if (original != null) {
                ctx.Entry(original).CurrentValues.SetValues(newLoja);
                ctx.SaveChanges();
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

    }
}
