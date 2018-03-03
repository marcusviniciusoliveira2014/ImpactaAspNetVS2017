using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorio.SistemaArquivos
{
    public class VeiculoRepositorio
    {
        private string _CaminhoArquivoVeiculo = ConfigurationManager.AppSettings["CaminhoArquivoVeiculo"];

        public void Inserir( Veiculo veiculo)
        {
            var veiculos = XDocument.Load(_CaminhoArquivoVeiculo);

            var registro = new StringWriter();
            new XmlSerializer(typeof(Veiculo)).Serialize(registro,veiculo);
            veiculos.Root.Add( XElement.Parse(registro.ToString()));

            veiculos.Save(_CaminhoArquivoVeiculo);

        }
        
    }
}
