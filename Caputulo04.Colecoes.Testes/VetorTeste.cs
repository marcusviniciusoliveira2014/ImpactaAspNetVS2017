using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;

namespace Caputulo04.Colecoes.Testes
{
    [TestClass]
    public class VetorTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var strings = new string[10];

            strings[0] = "string 1";
         //   strings[10] = "string 11"; //Erro indice fora da lista.
         //   var veiculos = new Veiculo[1000];

            var decimais = new decimal[3] { 1.7m, 0.3m, 15 };


            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"Tamanho do Vetor : {decimais.Length}" );




        }

        [TestMethod]
        public void RedimencionamentoTeste()
        {
            decimal[] decimais = { 1.7m, 0.3m, 15 };

            Array.Resize(ref decimais, 4);

            decimais[3] = 17.2m;

        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            decimal[] decimais = { 1.7m, 0.3m, 15 };

            Array.Sort(decimais);
            Assert.IsTrue(decimais[0] == 0.3m);
        }

        public decimal CalculaMedia(decimal valor1, decimal valor2) {
            var resp = ((valor1 + valor2) / 2);
            return resp;
        }

        [TestMethod]
        public void MediaTeste()
        {
            decimal[] decimais = { 1.7m, 0.3m, 15 };

            Console.WriteLine(CalculaMedia(1.7m, 0.3m, 15,56.7m));   


        }


        public decimal CalculaMedia(params decimal[] values)
        {
            decimal resp = 0m;
            foreach (var item in values)
            {
                //  resp = resp + item; 
                resp += item;
            }
            return (resp / values.Length);
        }



    }
}
