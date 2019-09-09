using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor.Pages.Operacoes
{
    public class EditModel : PageModel
    {
        private readonly ICarteiraData data;
        private readonly IHtmlHelper htmlHelper;

        public Operacao Operacao { get; set; }

        public IEnumerable<SelectListItem> OperacaoTipos { get; set; }

        public EditModel(ICarteiraData data, IHtmlHelper htmlHelper)
        {
            this.data = data;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet()
        {
            OperacaoTipos = htmlHelper.GetEnumSelectList<OperacaoTipo>();
        }
    }
}