using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorio.SqlServer.EFCodeFirst.ModelConfiguration
{
    public class CategoriaConfiguratuion : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguratuion()
        {
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}