using Microsoft.AspNetCore.Mvc;
using MinhaCarteiraRazor.Core.Entities;
using System.Collections.Generic;

namespace MinhaCarteiraRazor.ViewComponents
{
    public class CarteiraListViewComponent : ViewComponent
    {
        public CarteiraListViewComponent()
        {
        }

        public IViewComponentResult Invoke(IEnumerable<Carteira> lista)
        {
            return View(lista);
        }
    }
}
