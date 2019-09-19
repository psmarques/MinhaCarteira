using Microsoft.AspNetCore.Http;
using MinhaCarteiraRazor.Core.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace MinhaCarteiraRazor.Configuration
{
    public static class AuthUtil
    {
        public static Usuario GetUsuarioLogado(HttpContext ctx)
        {
            if (ctx == null || ctx.User == null) return null;

            var usr = new Usuario();
            var lstRoles = new List<string>();

            foreach(var item in ctx.User.Claims)
            {
                if(item.Type == ClaimTypes.Sid)
                {
                    int id = 0;
                    int.TryParse(item.Value, out id);
                    usr.Id = id;
                }
                else if(item.Type == ClaimTypes.Name)
                {
                    usr.Nome = item.Value;
                }
                else if(item.Type == ClaimTypes.Email)
                {
                    usr.Email = item.Value;
                }
                else if(item.Type == ClaimTypes.Role)
                {
                    lstRoles.Add(item.Value);
                }
            }


            return usr;
        }

    }
}
