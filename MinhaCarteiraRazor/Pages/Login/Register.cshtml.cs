using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Core.Util;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor.Pages.Login
{
    public class RegisterModel : PageModel
    {
        private readonly IUsuarioData data;

        [BindProperty]
        public Usuario UsuarioCadastro { get; set; }

        [BindProperty]
        public string Hash2 { get; set; }


        public RegisterModel(IUsuarioData data)
        {
            this.data = data;
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (UsuarioCadastro.Hash == Hash2)
                {
                    UsuarioCadastro.Hash = new PasswordHasher<string>().HashPassword(UsuarioCadastro.Nome, UsuarioCadastro.Hash);

                    data.Add(UsuarioCadastro);
                    data.Commit();

                    TempData.Add("Message", Messages.MSG_USUARIO_CRIADO_SUCESSO);

                    return RedirectToPage(Core.Util.Pages.LoginSignIn);
                }
                else
                {
                    ModelState.AddModelError("Hash", Messages.MSG_USUARIO_PASSWD_DIFERENTES);
                }
 
            }

            return Page();
        }
    }
}