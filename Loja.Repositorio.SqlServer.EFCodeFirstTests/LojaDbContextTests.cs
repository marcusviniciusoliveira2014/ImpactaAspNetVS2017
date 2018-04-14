using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using System.Linq;
using System.Data.Entity;
using System.Diagnostics;

namespace Loja.Repositorio.SqlServer.EFCodeFirst.Tests
{

    [TestClass()]
    public class LojaDbContextTests
    {
        LojaDbContext _db = new LojaDbContext();


        public LojaDbContextTests()
        {

            _db.Database.Log = LogarQueries;

        }

        private void LogarQueries(string Query)
        {
            Debug.Write(Query);
        }

        [TestMethod()]
        public void SelecionarTodasCategoriasTeste()
        {
            var categorias = _db.Categorias.ToList();
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            Produto produto = new Produto();
            produto.Nome = "Caneta";
            produto.preco = 20.00m;
            produto.Estoque = 50;

           // produto.Categoria = new Categoria { Nome = "Prfumaria" };
            produto.Categoria =    _db.Categorias.Single(c => c.Id == 1);

            _db.Produtos.Add(produto);
            _db.SaveChanges();

        }


        [TestMethod]
        public void EditarProdutoTeste()
        {
            var produto = (from p in _db.Produtos
                where p.Nome == "Caneta"
                select p).First();

            produto.preco = 16.54m;

            produto.Nome = "Barbeador Editado";

            _db.SaveChanges();

        }


        [TestMethod]
        public void ExcluirPeodutoTeste()
        {
            var produto = _db.Produtos.Single(p => p.Id == 1);
            _db.Produtos.Remove(produto);
            _db.SaveChanges();
        }


        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            var produto = _db.Produtos.Single(p => p.Id == 1);

            Assert.IsNull(produto.Categoria);

        }


        [TestMethod]
        public void IncludeTeste()
        {
            var produto = _db.Produtos.Include(p => p.Categoria).Single(p => p.Id == 4);
            Assert.IsTrue(produto.Categoria.Nome == "Perfumaria");

        }


        [TestMethod]
        public void QueryableTeste()
        {
            var query = _db.Produtos.Where(p => p.preco > 10);

            if (true)
            {
                query = query.Where(p => p.Estoque > 5);
            }

            query = query.OrderBy(p => p.preco);

            var primeiro = query.First();
          //  var ultimo = query.Last();
            var unico = query.Single();
            var todos = query.ToList();


        }



    }
}