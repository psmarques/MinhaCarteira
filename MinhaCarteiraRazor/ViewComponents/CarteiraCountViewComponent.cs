using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor.ViewComponents
{
    public class CarteiraCountViewComponent : ViewComponent
    {
        private readonly ICarteiraData data;


        public CarteiraCountViewComponent(ICarteiraData data)
        {
            this.data = data;
        }

        public IViewComponentResult Invoke()
        {
            var count = data.GetCount();
            return View(count);
        }
    }
}
