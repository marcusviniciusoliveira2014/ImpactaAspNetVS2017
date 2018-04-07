using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorio.SqlServer.EFCodeFirst.ModelConfiguration
{
    public class ProdutoConfiguratuion : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguratuion()
        {
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.preco)
                .HasPrecision(9,2);

            HasRequired(p => p.Categoria);

        }
    }
}