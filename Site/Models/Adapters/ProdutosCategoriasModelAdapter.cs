using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Adapters {
    public class ProdutosCategoriasModelAdapter {
        public List<Produto> Produtos { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}