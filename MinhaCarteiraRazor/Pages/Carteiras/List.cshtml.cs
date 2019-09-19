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

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync()
        {
            var user = Configuration.AuthUtil.GetUsuarioLogado(HttpContext);

            if (!string.IsNullOrEmpty(FiltroNome))
            {
                LstCarteira = data.GetByName(FiltroNome, user.Id);
            }
            else
            {
                LstCarteira = data.GetAll(user.Id);
            }

            return Page();
        }
    }
}