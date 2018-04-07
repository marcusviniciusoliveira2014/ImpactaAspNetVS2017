using Pessoal.Dominio;
using Pessoal.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Tarefas_Create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gravarButton_Click(object sender, EventArgs e)
    {
        Tarefa tarefa = new Tarefa();

        tarefa.Nome = NomeTextBox.Text;
        tarefa.Observacao = ObservacaoTextBox.Text;
        tarefa.Concluida = ConcluidaCheckBox.Checked;
        Enum.TryParse(PrioridadeDropDownList.SelectedValue, out Prioridade prioridadeselecionada);
        tarefa.Prioridade = prioridadeselecionada;

        new TarefaRepositorio().Inserir(tarefa);
        Response.Redirect("Default.aspx");

    }
}