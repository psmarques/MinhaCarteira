using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinhaCarteiraRazor.Pages.Login
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Nome { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Hash { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}