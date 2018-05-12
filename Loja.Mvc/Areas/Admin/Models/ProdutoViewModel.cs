using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Loja.Mvc.Areas.Admin.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Display(Name ="Codigo Categoria")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        public List<SelectListItem> Categorias { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public Decimal preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        
        public bool Ativo { get; set; }

    }
}