﻿using Loja.Mvc.Models;
using Loja.Mvc.Validacoes;

namespace Loja.Mvc.Controllers
{
    internal class Mapear
    {
        private ProdutoViewModel viewModel;

        public Mapear(ProdutoViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}