using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor.Pages.Operacoes
{
    public class ListModel : PageModel
    {
        private readonly IOperacaoData data;

        [BindProperty]
        public IEnumerable<Operacao> Lista { get; set; }

        public ListModel(IOperacaoData data)
        {
            this.data = data;
        }

        public void OnGet()
        {
            Lista = data.GetAll(Configuration.AuthUtil.GetUsuarioLogado(HttpContext).Id);
        }
    }
}