using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Dominio;
using Pessoal.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class TarefaRepositorioTests
    {
        private TarefaRepositorio _tarefarepositorio = new TarefaRepositorio();


        [TestMethod()]
        public void InserirTest()
        {
            var tarefa = new Tarefa();
            tarefa.Concluida = true;
            tarefa.Nome = "Teste de inserção2";
            tarefa.Prioridade = Prioridade.Baixa;
            tarefa.Observacao = "OBS Coreção 3";

            var id = _tarefarepositorio.Inserir(tarefa);
            Assert.IsTrue(id != 0);

        }

        [TestMethod]
        public void AtualizarTest()
        {
            var tarefa = new Tarefa();
            tarefa.Concluida = true;
            tarefa.Nome = "Teste de Mudança";
            tarefa.Prioridade = Prioridade.Baixa;
            tarefa.Observacao = "OBS Coreção 3";
            tarefa.Id = 6;

            _tarefarepositorio.Atualizar(tarefa);

        }


        [TestMethod]
        public void SelecionarTest() { }

        [TestMethod()]
        public void SelecionarTest1()
        {
            var tarefas = _tarefarepositorio.Selecionar();
            Assert.IsTrue(tarefas.Count != 0);
        }

        [TestMethod()]
        public void SelecionarComId()
        {
            var tarefa = _tarefarepositorio.Selecionar(2);
            Console.WriteLine(tarefa.Id);

        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _tarefarepositorio.Excluir(4);

            var tarefa = _tarefarepositorio.Selecionar(4);
            Assert.IsNull(tarefa);

        }
    }
}