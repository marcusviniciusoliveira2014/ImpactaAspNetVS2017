using Pessoal.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pessoal.Repositorios.SqlServer
{
    public class TarefaRepositorio
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["PessoalConnectionString"].ConnectionString;
            
        public int Inserir(Tarefa tarefa)
        {

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                const string nomeProcedure = "TarefaInserir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa));

                    return (int)comando.ExecuteScalar();
                }

            }           
        }


        public void Atualizar(Tarefa tarefa)
        {

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                const string nomeProcedure = "TarefaAtualizar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa));

                    comando.ExecuteNonQuery();
                }

            }
        }

        public List<Tarefa> SelecionarTodos()
        {

            var tarefas = new List<Tarefa>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                const string nomeProcedure = "TarefaSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (var registro = comando.ExecuteReader())
                    {

                        while (registro.Read())
                        {
                            tarefas.Add(Mapear(registro))

                        }


                    }

                }

            }

            return tarefas;
        }

        private Tarefa Mapear(SqlDataReader registro)
        {
            
            Paramos aqui


        }

        private SqlParameter[] Mapear(Tarefa tarefa)
        {
            var parametros = new List<SqlParameter>();

            if (tarefa.Id != 0)
            {
                parametros.Add(new SqlParameter("@id", tarefa.Id));
            }

            parametros.Add(new SqlParameter("@nome", tarefa.Nome));
            parametros.Add(new SqlParameter("@prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@observacao", tarefa.Observacao));

            return parametros.ToArray();
        }


        /*
         
         
create table tarefa(
         Id integer not null primary key identity,
         Nome nvarchar(200) not null,
         Prioridade integer default 0,
         Concluida bit, 
         Observacao nvarchar(1000) 
);





create procedure tarefaInserir  
   @nome nvarchar(200), 
   @prioridade int,
   @concluida bit,
   @observacao nvarchar(1000)
as 
  begin
    insert into tarefa(nome, prioridade, Concluida, observacao) 
	output inserted.Id
	values(@nome,@prioridade, @concluida, @observacao)

  end


exec tarefaInserir'Tatu3', 1, 1, 'teste3'


create procedure tarefaAtualizar

   @Id int,	
   @nome nvarchar(200), 
   @prioridade int,
   @concluida bit,
   @observacao nvarchar(1000)

as 
begin

	update tarefa set 
	  nome = @nome,
	  prioridade = @prioridade, 
	  concluida =@concluida, 
	  observacao = @observacao 
	  where Id = @Id
end

exec tarefaAtualizar 3,'Tatu12', 1, 1, 'teste';


create procedure tarefaSelecionar @Id int = null
as 
begin
   
   select Id, Nome, Prioridade, Concluida, Observacao 
   from tarefa
   where id = ISNULL(@id, id)
   order by concluida, prioridade, nome

end


exec tarefaselecionar 4


create procedure tarefaExcluir @Id int 
as 
begin
  delete from tarefa where id = @Id 
end


exec tarefaExcluir 3         
         
         
         */



    }
}
