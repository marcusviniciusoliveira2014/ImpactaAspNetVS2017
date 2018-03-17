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
    public class MarcaRepositorio
    {

        private string _CaminhoArquivoMarca = ConfigurationManager.AppSettings["CaminhoArquivoMarca"];

        //ToDo: Polimorfismo por sobrecarga
        public List<Marca> Selecionar()
        {

            var marcas = new List<Marca>();

            foreach (var Linha in File.ReadAllLines(_CaminhoArquivoMarca))
            {

                //1;Ford 
                var propriedades = Linha.Split(';');

                var marca = new Marca();
                marca.Id = Convert.ToInt32(propriedades[0]);
                marca.Nome = propriedades[1];

                marcas.Add(marca);

            }


            return marcas;

        }

        public Marca Selecionar(int marcaId) {

            Marca marca = null;

            foreach (var Linha in File.ReadAllLines(_CaminhoArquivoMarca))
            {

                //1;Ford 
                var propriedades = Linha.Split(';');

                if (propriedades[0] == marcaId.ToString())
                {

                    marca = new Marca();
                    marca.Id = Convert.ToInt32(propriedades[0]);
                    marca.Nome = propriedades[1];

                    break;
                }

            }

            return marca;

        }



    }
}
