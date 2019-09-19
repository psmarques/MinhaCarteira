using Microsoft.AspNetCore.Mvc;
using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaCarteiraRazor.ViewComponents
{
    public class OperacaoListViewComponent : ViewComponent
    {
        public OperacaoListViewComponent()
        {

        }

        public IViewComponentResult Invoke(IEnumerable<Operacao> lista)
        {
            return View(lista);
        }
    }
}
