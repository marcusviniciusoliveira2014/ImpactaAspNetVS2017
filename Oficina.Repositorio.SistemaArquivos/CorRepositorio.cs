using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorio.SistemaArquivos
{
    public class CorRepositorio
    {

        public List<Cor> Selecionar()
        {

            var cores = new List<Cor>();

            foreach (var Linha in File.ReadAllLines(@"Dados\Cor.txt"))
            {

                //00001Preto 
                var cor = new Cor();

                cor.Id = Convert.ToInt32(Linha.Substring(0, 5));
                cor.Nome = Linha.Substring(5);

                cores.Add(cor);

            }
            return cores;
        }

        


    }
}
