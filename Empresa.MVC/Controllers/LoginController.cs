using Empresa.MVC.Models;
using Empresa.Repositorios.SqlServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Empresa.MVC.Controllers
{
    public class LoginController:Controller
    {

        private readonly EmpresaDbContext _context;
        private readonly IDataProtector _protectorProvider;

        public LoginController(EmpresaDbContext context, IDataProtectionProvider protectionProvider, IConfiguration configuration)
        {
            _context = context;
            _protectorProvider = protectionProvider.CreateProtector(configuration.GetSection("ChaveCriptografia").Value);
        }

        public IActionResult Index() {

            return View();

        }


        [HttpPost]
        public IActionResult Index(LoginViewModel viewModel)
        {
            if (! ModelState.IsValid)
            {
                return View(viewModel);
            }

            var contato = _context.Contatos.SingleOrDefault(c => c.Email == viewModel.Email && _protectorProvider.Unprotect(c.Senha) == viewModel.Senha);

            if (contato == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário/senha incorretos.");
                return View(viewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, contato.Nome),
                new Claim(ClaimTypes.Email, contato.Email),
                new Claim(ClaimTypes.Role, "Adimin"),
                new Claim(ClaimTypes.Role, "Vendedor"),
                new Claim(ClaimTypes.Role, "Master"),
                new Claim("Contato", "Excluir")
            };

            var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identidade);


            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index","Contatos");

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index","Contatos");
        }


    }
}
