using Loja.Dominio;
using Loja.Repositorio.SqlServer.EFCodeFirst.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorio.SqlServer.EFCodeFirst
{
    public class LojaDbContext :DbContext
    {

        public LojaDbContext():base("lojaConnectionString")
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguratuion());
            modelBuilder.Configurations.Add(new CategoriaConfiguratuion());


        }
    }
}
