using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models;

namespace Site.Controllers {
    public class WebServiceController : Controller {
        //
        // GET: /WebService/
        public ActionResult Index() {
            return View();
        }


        //
        // GET: /WebService/Products
        [HttpGet]
        public JsonResult Products() {
            var ctx = new ERPDBModelContainer();
            var temp = new List<dynamic>();
            foreach (Produto p in ctx.ProdutoSet.ToList()) {
                if (p.Categoria != null)
                    temp.Add(new {
                        Id = p.Id, Nome = p.Nome, PrecoCusto = p.PrecoCusto, PrecoVista = p.PrecoVista,
                        PrecoPrazo = p.PrecoPrazo, Quantidade = p.Quantidade, DisponivelLojaVirtual = p.DisponivelLojaVirtual,
                        Descricao = p.Descricao, UnidadeMedida = p.UnidadeMedida, Imagem = p.Imagem, Codigo = p.Codigo, 
                        ProdutoVendaItem = p.ProdutoVendaItem, Categoria = new { Id = p.Categoria.Id, Nome = p.Categoria.Nome }
                    });
                else
                    temp.Add(new {
                        Id = p.Id, Nome = p.Nome, PrecoCusto = p.PrecoCusto, PrecoVista = p.PrecoVista,
                        PrecoPrazo = p.PrecoPrazo, Quantidade = p.Quantidade, DisponivelLojaVirtual = p.DisponivelLojaVirtual,
                        Descricao = p.Descricao, UnidadeMedida = p.UnidadeMedida, Imagem = p.Imagem, Codigo = p.Codigo,
                        ProdutoVendaItem = p.ProdutoVendaItem, Categoria = p.Categoria
                    });
            }

            return Json(temp, JsonRequestBehavior.AllowGet);
        }


        //
        // POST: /WebService/Products
        [HttpPost]
        public JsonResult Products(List<Produto> produtos) {
            var r = new List<Produto>();
            if (produtos != null) {
                using (var ctx = new ERPDBModelContainer()) {
                    var l = ctx.ProdutoSet.ToList();
                    foreach (Produto p in produtos) {
                        if (l.FirstOrDefault(o=>o.Codigo == p.Codigo)==null) { ctx.ProdutoSet.Add(p); ctx.SaveChanges(); } else { r.Add(p); }
                    }
                }
            } else { r = null; }
            return Json(r);
        }


        //
        //SECURE GET: /WebService/Vendas
        [HttpPost]
        public JsonResult Vendas(string apikey) {
            if(apikey=="udtcapituntn"){
                var ctx = new ERPDBModelContainer();
                return Json(ctx.VendaSet.ToList());
            } else { return Json(""); }
        }
    }
}