using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Core.Util;
using MinhaCarteiraRazor.Data;
using System.Linq;

namespace MinhaCarteiraRazor.Pages.Carteiras
{
    public class EditModel : PageModel
    {
        private readonly ICarteiraData data;

        [BindProperty]
        public Carteira Carteira { get; set; }

        public List<Claim> LstClaim { get; set; }

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
                return RedirectToPage(Core.Util.Pages.CarteirasNotFound);

            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Carteira.Usuario = Configuration.AuthUtil.GetUsuarioLogado(HttpContext);

            if (Carteira.Id > 0)
            {
                
                Carteira = data.Update(Carteira);
                TempData["Message"] = Messages.MSG_CARTEIRA_ALTERADA;
            }
            else
            {
                Carteira = data.Add(Carteira);
                TempData["Message"] = Messages.MSG_CARTEIRA_CRIADA;
            }

            data.Commit();

            return RedirectToPage(Core.Util.Pages.CarteirasList);
        }
    }
}