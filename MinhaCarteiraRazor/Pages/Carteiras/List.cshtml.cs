using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor.Pages.Carteiras
{
    public class ListModel : PageModel
    {
        private readonly ICarteiraData data;

        [BindProperty(SupportsGet = true)]
        public string FiltroNome { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ModoView { get; set; }

        public IEnumerable<Carteira> LstCarteira { get; set; }

        public ListModel(ICarteiraData data)
        {
            this.data = data;
        }

        public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(FiltroNome))
            {
                LstCarteira = data.GetByName(FiltroNome);
            }
            else
            {
                LstCarteira = data.GetAll();
            }

            return Page();
        }
    }
}