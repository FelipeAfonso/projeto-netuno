using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models.Adapters;

namespace Site.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            StartSession();
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            StartSession();
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            StartSession();
            return View();
        }

        public ActionResult Produtos() {
            ViewBag.Message = "Produtos";
            StartSession();
            var ctx = new ERPDBModelContainer();
            return View(new ProdutosCategoriasModelAdapter() { Produtos = ctx.ProdutoSet.ToList(), Categorias = ctx.CategoriaSet.ToList() });
        }
        [HttpGet]
        public ActionResult Comprar(string id) {
            try { var ctx = new ERPDBModelContainer(); return View(ctx.ProdutoSet.Single(o=>o.Nome == id)); } 
            catch { return HttpNotFound(); }
        }
        [HttpPost]
        public ActionResult Comprar(string id, bool post) {
            try {
                var qtd = Convert.ToInt32(Request["txtQtd"].ToString());
                if (Session["carrinho"] == null) {
                    Session.Add("carrinho", new List<ProdutoVendaItem>());
                }
                var ctx = new ERPDBModelContainer();

                var exists = false;
                foreach (ProdutoVendaItem pvi in (List<ProdutoVendaItem>)Session["carrinho"]) {
                    if (pvi.Produto.Nome == id) { pvi.Quantidade += qtd; exists = true; }
                }
                if(!exists)
                    ((List<ProdutoVendaItem>)Session["carrinho"]).Add(new ProdutoVendaItem() { Produto = ctx.ProdutoSet.Single(o => o.Nome == id), Quantidade = qtd });
                //Response.Redirect("Carrinho");
                return Redirect("/Home/Carrinho");
            } catch { return HttpNotFound(); }
        }
        [HttpGet]
        public ActionResult Carrinho() {
            if (Session["carrinho"] == null) { return Content("O Carrinho está Vazio!"); }
            var ctx=  new ERPDBModelContainer();
            return View(new PVIsCategoriasModelAdapter() { PVI = (List<ProdutoVendaItem>)Session["carrinho"], Categoria = ctx.CategoriaSet.ToList() });
        }
        [HttpPost]
        public ActionResult Carrinho(bool post) {
            if (Request.IsAuthenticated) {
                try {
                    var venda = new Venda() { Data = DateTime.Now, Total=0 };
                    ERPDBModelContainer ctx = new ERPDBModelContainer();
                    var l = new List<ProdutoVendaItem>();
                    foreach (ProdutoVendaItem pvi in (List<ProdutoVendaItem>)Session["carrinho"]) {
                        var pr = ctx.ProdutoSet.Single(p => p.Id == pvi.Produto.Id);
                        ctx.ProdutoSet.Attach(pr);
                        ctx.ProdutoSet.Single(p=>p.Id == pvi.Produto.Id).Quantidade -= pvi.Quantidade;
                        l.Add(new ProdutoVendaItem() { Produto = pr, Quantidade = pvi.Quantidade, Venda = null });
                        venda.Total += pr.PrecoVista * pvi.Quantidade;
                    }
                    venda.ProdutoVendaItem = l;
                    var email = (((Cliente)Session["usuario"]) != null)?((Cliente)Session["usuario"]).Email : User.Identity.Name;
                    ctx.UsuarioSet.OfType<Cliente>()
                        .Single(o =>
                            o.Email == email)
                        .Venda
                        .Add(venda);
                    ctx.SaveChanges();
                } catch { return HttpNotFound(); }
                return Content("Venda Realizada com sucesso!");
            } else { return Redirect("/Account/Login"); }
        }

        private void StartSession() {
            if (User.Identity.IsAuthenticated) {
                if (Session["username"] == null) {
                    using (var ctx = new ERPDBModelContainer()) {
                        var u = ctx.UsuarioSet.Single(o => o.Email == User.Identity.Name);
                        Session["username"] = u.Nome;
                        Session["id"] = u.Id;
                    }
                }
            }
        }
    }
}