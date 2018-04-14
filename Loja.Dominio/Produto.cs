using System;

namespace Loja.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public Decimal preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }
        public virtual Categoria Categoria { get; set; } ///virtual liga o LadyLozer para trazer a categoria junto com o Produto
    }
}
