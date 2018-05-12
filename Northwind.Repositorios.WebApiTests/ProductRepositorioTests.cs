using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProductRepositorioTests
    {
        private ProductRepositorio _repositorio = new ProductRepositorio();

      

        [TestMethod()]
        public void PostTest()
        {

            var product = new ProductViewModel();
            product.ProductName = "Café";
            product.UnitsInStock = 35;
            product.UnitPrice = 11.37m;

            var response = _repositorio.Post(product).Result;
            Console.WriteLine(response.ProductID);

        }
        
        [TestMethod()]
        public void PutTest()
        {

            var product = new ProductViewModel();
            product.ProductName = "Café Com Chocolate";
            product.UnitsInStock = 387;
            product.UnitPrice = 15.37m;
            product.ProductID = 84;

            _repositorio.Put(product.ProductID, product).Wait();

            var response = _repositorio.Get(84).Result;

            Assert.AreEqual(response.UnitPrice, 15.37m);
        }


        [TestMethod]
        public void GetTest()
        {
           
            var produtos = _repositorio.Get().Result;
            Assert.IsTrue(produtos.Count > 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            _repositorio.Delete(84).Wait();

            var product = _repositorio.Get(84).Result;

            Assert.IsNull(product);


        }
        
        [TestMethod]
        public void GetProductOrdesTest()
        {
            var pedidos = _repositorio.GetProductOrders(34).Result;
            Assert.IsTrue(pedidos.Count > 0);

        }
        
    }
}