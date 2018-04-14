using System;
using System.Collections.Generic;
using System.Data.Entity;
using Loja.Dominio;

namespace Loja.Repositorio.SqlServer.EFCodeFirst
{
    internal class LojaDbInicializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());

            context.SaveChanges();
        }

        private IEnumerable<Produto> ObterProdutos()
        {
            var Grampeador = new Produto();

            Grampeador.Categoria = new Categoria { Nome = "Papelaria" };
            Grampeador.Nome = "Grampeador";
            Grampeador.preco = 12.30m;
            Grampeador.Estoque = 50;
            Grampeador.Ativo = false;



            var PenDriver = new Produto();
            PenDriver.Categoria = new Categoria { Nome = "Informatica" };
            PenDriver.Nome = "PenDriver";
            PenDriver.preco = 10.30m;
            PenDriver.Estoque = 150;
            PenDriver.Ativo = false;





            return new List<Produto> {Grampeador, PenDriver};


        }
    }
}