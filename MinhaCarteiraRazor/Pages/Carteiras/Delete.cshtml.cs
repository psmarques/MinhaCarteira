using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor.Pages.Carteiras
{
    public class DeleteModel : PageModel
    {
        private readonly ICarteiraData data;

        public Carteira Carteira { get; set; }

        public DeleteModel(ICarteiraData data)
        {
            this.data = data;
        }
        public IActionResult OnGet(int carteiraId)
        {
            Carteira = data.GetById(carteiraId);

            if (Carteira == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult OnPost(int carteiraId)
        {
            Carteira = data.GetById(carteiraId);

            if (Carteira == null)
            {
                return RedirectToPage("./NotFound");
            }

            data.Delete(Carteira);
            data.Commit();

            TempData["Message"] = "Carteira excluída com sucesso!";
            return RedirectToPage("./List");
        }
    }
}