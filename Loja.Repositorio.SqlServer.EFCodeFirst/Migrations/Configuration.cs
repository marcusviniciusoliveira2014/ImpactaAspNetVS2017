namespace Loja.Repositorio.SqlServer.EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Loja.Repositorio.SqlServer.EFCodeFirst.LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorio.SqlServer.EFCodeFirst.LojaDbContext";
        }

        protected override void Seed(Loja.Repositorio.SqlServer.EFCodeFirst.LojaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
