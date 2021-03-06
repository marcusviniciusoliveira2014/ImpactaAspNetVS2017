﻿using Oficina.Dominio;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorio.SistemaArquivos
{
    public class VeiculoRepositorio
    {
        private string _CaminhoArquivoVeiculo = ConfigurationManager.AppSettings["CaminhoArquivoVeiculo"];

        public void Inserir( VeiculoPasseio veiculo)
        {
            var veiculos = XDocument.Load(_CaminhoArquivoVeiculo);

            var registro = new StringWriter();
            new XmlSerializer(typeof(VeiculoPasseio)).Serialize(registro,veiculo);
            veiculos.Root.Add( XElement.Parse(registro.ToString()));

            veiculos.Save(_CaminhoArquivoVeiculo);

        }
        
    }
}
