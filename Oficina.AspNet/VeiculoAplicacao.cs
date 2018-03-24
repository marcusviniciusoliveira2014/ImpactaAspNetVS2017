using Oficina.Dominio;
using Oficina.Repositorio.SistemaArquivos;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.AspNet
{
    public class VeiculoAplicacao
    {
        private CorRepositorio _corRepositorio = new CorRepositorio();
        private MarcaRepositorio _marcaRepositorio = new MarcaRepositorio();
        private ModeloRepositorio _modeloRepositorio = new ModeloRepositorio();
        private VeiculoRepositorio _veiculoRepositorio = new VeiculoRepositorio();

        public VeiculoAplicacao()
        {
            PopularControles();
        }

        public List<Marca> Marcas { get; private set; }
        public string MarcaSelecionada { get; private set; }
        public List<Modelo> Modelos { get; private set; } = new List<Modelo>();
        public List<Cor> Cores { get; private set; }
        public List<Combustivel> Combustiveis { get; private set; }
        public List<Cambio> Cambios;

        private void PopularControles()
        {
            Marcas = _marcaRepositorio.Selecionar();

            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];
            if (!String.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = _modeloRepositorio.SelecionarPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            //  ObterVeiculos();

            Cores = _corRepositorio.Selecionar();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();
        }

        private void ObterVeiculos()
        {
            var veiculos = new List<Veiculo>();
            for (int i = 0; i < 10000000; i++)
            {
                veiculos.Add(new VeiculoPasseio());

            }
        }

        public void inserir()
        {
            try
            {
                var veiculo = new VeiculoPasseio();
                var formulario = HttpContext.Current.Request.Form;

                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);
                veiculo.Cor = _corRepositorio.Selecionar(Convert.ToInt32(formulario["cor"]));
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
                veiculo.Modelo = _modeloRepositorio.Selecionar(Convert.ToInt32(formulario["modelo"]));
                veiculo.Placa = formulario["placa"];
                veiculo.Observacao = formulario["observacao"];

                veiculo.Carroceria = TipoCarroceria.Hatch;

                _veiculoRepositorio.Inserir(veiculo);

            }
            catch (FileNotFoundException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"O arquivo {ex.FileName} não foi encontrado");
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"Arquivo veiculo.xml nao preparado para gravação.");
                throw;

            }
            catch (DirectoryNotFoundException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"A pasta do veiculo.xml sem opção de gravação");
                throw;

            }

            catch (Exception ex)
            {
                //Logar o objeto de exception ex;
                HttpContext.Current.Items.Add("MensagemErro", $"OOPs! Ocorreu um erro e sua ação não foi realizada.");
                throw;
            }
            finally
            {
                //chamado sempre, independente de erro ou sucesso', é executado sempre e mesmo tendo um return
            }
        }


    }
}