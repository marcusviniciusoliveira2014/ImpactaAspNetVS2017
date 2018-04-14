namespace Loja.Repositorio.SqlServer.EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarProdutoDescontinuadoParaAtivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false));
            Sql("update produto set ativo = Descontinuado ^ 1");
            DropColumn("dbo.Produto", "Descontinuado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Descontinuado", c => c.Boolean(nullable: false));
            Sql("update produto set Descontinuado = ativo ^ 1");
            DropColumn("dbo.Produto", "Ativo");
        }
    }
}
