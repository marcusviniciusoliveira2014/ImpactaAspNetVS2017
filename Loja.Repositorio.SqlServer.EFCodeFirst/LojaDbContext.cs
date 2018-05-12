using Loja.Dominio;
using Loja.Repositorio.SqlServer.EFCodeFirst.Migrations;
using Loja.Repositorio.SqlServer.EFCodeFirst.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorio.SqlServer.EFCodeFirst
{
    public class LojaDbContext :IdentityDbContext  
    {

        public LojaDbContext():base("lojaConnectionString")
        {
            /*
              No construtor da classe dbContext informar se o sistema vai dropar a base de dados
              e recria-la  ==>  Database.SetInitializer(new LojaDbInicializer());
              utilizar quando a base de dados(local) nao esta em producao ainda.            
              Database.SetInitializer(new LojaDbInicializer()); 
             */

            //  Database.SetInitializer(new LojaDbInicializer()); 

            /*
             * Prestar a atencao sintaxe abaixo executada quando a base  de dados esta em producao.
             * Migrations vai atualizar a base de dados.
             */
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            /*
              modificar o jeito de ser criada as tabelas no banco ao inves de Produtos cria como Produto
              Cria as tabelas no singular e nao no plural. ==> conforme abaixo.
            */

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguratuion());
            modelBuilder.Configurations.Add(new CategoriaConfiguratuion());


        }
    }
}
