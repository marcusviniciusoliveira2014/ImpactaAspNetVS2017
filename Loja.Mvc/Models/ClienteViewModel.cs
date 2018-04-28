using Loja.Mvc.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Models

{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Nascimento")]
        [IdadeMinima(18)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Remote("VerificarDisponibilidadeEmail", "Clientes", HttpMethod = "POST", ErrorMessage = "Email já utilizado...!")]
        [RegularExpression(@"^[a-zA-z0-9.-_]{1,200}@[\w]+(\.[a-zA-Z]{2,5}){1,2}$", ErrorMessage ="Emai no formato invalido...!")]
        //https://regex101.com/r/mFKhDl/3/codegen?language=csharp
        //[EmailAddress]
        public String Email { get; set; }
    }
}