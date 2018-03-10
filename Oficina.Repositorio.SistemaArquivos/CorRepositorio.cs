using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorio.SistemaArquivos
{
    public class CorRepositorio
    {
        string _CaminhoArquivoCor = ConfigurationManager.AppSettings["CaminhoArquivoCor"];

        public List<Cor> Selecionar()
        {

            var cores = new List<Cor>();
          

           // foreach (var Linha in File.ReadAllLines(@"Dados\Cor.txt"))
            foreach (var Linha in File.ReadAllLines(_CaminhoArquivoCor))
            {
                //00001Preto 
                var cor = new Cor();

                cor.Id = Convert.ToInt32(Linha.Substring(0, 5));
                cor.Nome = Linha.Substring(5);

                cores.Add(cor);

            }
            return cores;
        }

        public Cor Selecionar(int corId)
        {

            Cor cor = null;

            foreach (var Linha in File.ReadAllLines(_CaminhoArquivoCor))
            {

                if (Convert.ToInt32(Linha.Substring(0,5)) == corId)
                {
                    cor = new Cor();
                    cor.Id = Convert.ToInt32(Linha.Substring(0, 5));
                    cor.Nome = Linha.Substring(5);

                    break;
                }

            }


            return cor;

        }
    }
}
