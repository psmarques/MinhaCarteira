using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICarteiraData data;

        public List<Carteira> LstTop5Carteiras { get; set; }

        public IndexModel(ICarteiraData data)
        {
            this.data = data;
        }

        public void OnGet()
        {
            LstTop5Carteiras = data.GetTop5().ToList();
        }
    }
}
