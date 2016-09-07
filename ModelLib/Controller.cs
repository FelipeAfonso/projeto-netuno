using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelLib;
using System.Text.RegularExpressions;

namespace ModelLib {
    public static class Controller {

        public static Dictionary<string, Permissao> Permissoes = new Dictionary<string, Permissao>();

        public static Funcionario LoggedUser = new Administrador() { Nome = "Teste", Senha = "", Email = "asd@asd.com" };

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

    }
}
