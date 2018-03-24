using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;

namespace Caputulo04.Colecoes.Testes
{
    [TestClass]
    public class ListTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {

            var inteiros = new List<int>() {0,9,4,1};
            inteiros.Add(14);
            inteiros.Add(3);

            var intero = inteiros[0];

            var maisInteiros = new List<int>() { 1,8,3,0};
            inteiros.AddRange(maisInteiros);

            inteiros.Insert(0, 52); //empura o conteudo para frente
            inteiros.Remove(3); //remove o conteudo(3) nao é o indice.
            inteiros.RemoveAt(4); //remove o conteudo do indice 4.
            inteiros.Sort();
            var primeiro = inteiros[0];
            var ultimo = inteiros[inteiros.Count - 1];

            foreach (var item in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(item)} : {item}" );
            }

        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();
            //var viculos = new Dictionary<string, Veiculo>();
            feriados.Add(new DateTime(2018, 12, 25), "Natal");
            feriados.Add(Convert.ToDateTime("01/01/2019"), "Ano Novo");
            feriados.Add(Convert.ToDateTime("25/01/2019"), "Aniversario de São Paulo");

            var nomeFeriado = feriados[new DateTime(2018,12,25)];

            foreach (var feriado in feriados) //prestar a atenção
            {
                Console.WriteLine($"{feriado.Key.ToString("dd/MM/yyyy")} : {feriado.Value}");
            }

            Console.WriteLine( feriados.ContainsKey(Convert.ToDateTime("25/01/2019")));
            Console.WriteLine( feriados.ContainsValue("Ano Novo"));



        }

    }
}
