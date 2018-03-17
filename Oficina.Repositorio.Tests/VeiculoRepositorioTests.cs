using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using System.Linq;

namespace Oficina.Repositorio.SistemaArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var repositorio = new VeiculoRepositorio();
            var veiculo = new VeiculoPasseio();

            //veiculo.Id = 1;
            veiculo.Ano = 2014;
            veiculo.Cambio = Cambio.Manual;
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Cor = new CorRepositorio().Selecionar(1);
            veiculo.Marca = new MarcaRepositorio().Selecionar(1);
            veiculo.Modelo = new ModeloRepositorio().Selecionar(1);
            veiculo.Observacao = "Observar";
            veiculo.Placa = "ABC1234";
            veiculo.Carroceria = TipoCarroceria.Hatch;

            repositorio.Inserir(veiculo);

            System.Console.WriteLine( veiculo.ToString());

        }
    }
}