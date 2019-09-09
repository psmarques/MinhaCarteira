using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor.Pages.Carteiras
{
    public class EditModel : PageModel
    {
        private readonly ICarteiraData data;

        [BindProperty]
        public Carteira Carteira { get; set; }

        public EditModel(ICarteiraData data)
        {
            this.data = data;
        }

        public IActionResult OnGet(int? carteiraId)
        {
            if (carteiraId.HasValue)
                Carteira = data.GetById(carteiraId.Value);
            else
                Carteira = new Carteira();

            if (Carteira == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (Carteira.Id > 0)
            {
                Carteira = data.Update(Carteira);
                TempData["Message"] = "Carteira alterada com sucesso!";
            }
            else
            {
                Carteira = data.Add(Carteira);
                TempData["Message"] = "Carteira criada com sucesso!";
            }

            data.Commit();
            return RedirectToPage("./List");
        }
    }
}