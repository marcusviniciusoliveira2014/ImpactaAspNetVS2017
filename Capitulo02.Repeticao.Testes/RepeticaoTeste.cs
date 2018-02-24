using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo02.Repeticao.Testes
{
    [TestClass]
    public class RepeticaoTeste
    {
        [TestMethod]
        public void ForAninhadoTeste()
        {

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Tabuada do {i} ------------------------");

                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{1} * {j} = {i * j}");

                }
            }
        }

         [TestMethod]
        public void EstruturaForTeste()
        {
            int i = 1;

            for (Console.WriteLine("Iniciou"); i <= 3; Console.WriteLine(i))
            {
                i++;
            }
        }


        [TestMethod]
        public void ForApenasComCondicaoTeste()
        {
            var i = 1;

            for (; i <=3; )
            {
                Console.WriteLine(i++);
                //i++;
            }
        }


        [TestMethod]
        public void ContinueTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i <= 5)
                {
                    continue;
                }

                Console.WriteLine( i );

            }
        }


        [TestMethod]
        public void BreakTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i > 5)
                {
                    break;
                }
                Console.WriteLine(i);
            }
        }


        [TestMethod]
        public void WhileTeste()
        {
            var i = 1;

            while (i <= 10)
            {
                Console.WriteLine(i++);
               
            }

        }

        [TestMethod]
        public void DuoWhile()
        {
            do
            {
                Console.WriteLine("Entrou!");
            } while (1==2);
        }


    }
}
