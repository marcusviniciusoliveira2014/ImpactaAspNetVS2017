using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Models;
using Loja.Repositorio.SqlServer.EFCodeFirst;

namespace Loja.Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private LojaDbContext db = new LojaDbContext();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(Mapear(db.Produtos.ToList()));
        }

        private List<ProdutoViewModel> Mapear(List<Produto> produtos)
        {
            var viewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                viewModel.Add(Mapear(produto));
            }

            return viewModel;
        }

        private ProdutoViewModel Mapear(Produto produto)
        {
            var ViewModel = new ProdutoViewModel();

            ViewModel.preco = produto.preco;
            ViewModel.Nome = produto.Nome;
            ViewModel.Id = produto.Id;
            ViewModel.Estoque = produto.Estoque;
            ViewModel.Ativo = produto.Ativo;

            ViewModel.CategoriaId = produto.Categoria?.Id;
            ViewModel.CategoriaNome = produto.Categoria?.Nome;

            ViewModel.Categorias = Mapear(db.Categorias.ToList());

            return ViewModel;


        }

        private List<SelectListItem> Mapear(List<Categoria> categorias)
        {
            return categorias.Select(c => new SelectListItem {Text = c.Nome, Value = c.Id.ToString()}).ToList();
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(produto));
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {

            ViewBag.Titulo = "Novo Produto";
            // return View(Mapear(new Produto()));
            return View("~/Views/Produtos/CreateOrEdit.csHTML",Mapear(new Produto()));
        }

        // POST: Produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapear(ViewModel);

                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //return View(ViewModel);
            return View("~/Views/Produtos/CreateOrEdit.csHTML",ViewModel);

        }

        private Produto Mapear(ProdutoViewModel viewModel)
        {
            var produto = new Produto();

            produto.Categoria =   db.Categorias.Find(viewModel.CategoriaId);
            produto.Nome = viewModel.Nome;
            produto.Id = viewModel.Id;
            produto.Ativo = viewModel.Ativo;
            produto.preco = viewModel.preco;
            produto.Estoque = viewModel.Estoque;
            return produto;
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(produto));
        }

        // POST: Produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = db.Produtos.Find(viewModel.Id);
                Mapear(viewModel, produto);
                    
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        private void Mapear(ProdutoViewModel viewModel, Produto produto)
        {
            db.Entry(produto).CurrentValues.SetValues(viewModel);
            produto.Categoria = db.Categorias.Find(viewModel.CategoriaId);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(produto));
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
