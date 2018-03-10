using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorio.SistemaArquivos;

namespace Oficina.Repositorio.Tests
{
    [TestClass]
    public class CorRepositorioTests
    {
        [TestMethod]
        public void SelecionarTest()
        {

            var corRepositorio = new CorRepositorio();
            var cores = corRepositorio.Selecionar();

            foreach (var cor in cores)
            {
                Console.WriteLine($"{cor.Id} - {cor.Nome}");
            }

        }
    }
}
