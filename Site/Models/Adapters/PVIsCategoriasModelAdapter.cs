using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Adapters {
    public class PVIsCategoriasModelAdapter {
        public List<ProdutoVendaItem> PVI { get; set; }
        public List<Categoria> Categoria { get; set; }
    }
}