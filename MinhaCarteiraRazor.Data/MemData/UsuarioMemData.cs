using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinhaCarteiraRazor.Core.Entities;

namespace MinhaCarteiraRazor.Data.MemData
{
    public class UsuarioMemData : IUsuarioData
    {
        private List<Usuario> lstUsuarios;

        public UsuarioMemData()
        {
            lstUsuarios = new List<Usuario>();

            lstUsuarios.Add(new Usuario { Id = 1, Nome = "Paulo Marques", Email = "psmarques@gmail.com", Hash = "AQAAAAEAACcQAAAAEG7/p27qy0OgIveUGBFcRncDwAsfFNUQW9n5TUBa0kGT3aKdWXdRfehFtxilR8IDfQ==" });
            lstUsuarios.Add(new Usuario { Id = 2, Nome = "José da Silva", Email = "jsilva@gmail.com", Hash = "" });
            lstUsuarios.Add(new Usuario { Id = 3, Nome = "Ana Marchesi", Email = "anamarchesi@gmail.com", Hash = "" });
            lstUsuarios.Add(new Usuario { Id = 4, Nome = "João Barriga", Email = "jbarriga@gmail.com", Hash = "" });
        }

        public Usuario Add(Usuario newItem)
        {
            var nid = lstUsuarios.Max(x => x.Id) + 1;
            newItem.Id = nid;

            lstUsuarios.Add(newItem);
            return newItem;
        }

        public int Commit()
        {
            return 1;
        }

        public Usuario Delete(Usuario item)
        {
            var i = lstUsuarios.FirstOrDefault(x => x.Id == item.Id);
            if (i == null) return null;

            lstUsuarios.Remove(i);
            return item;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return lstUsuarios;
        }

        public Usuario GetById(int id)
        {
            return lstUsuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuario GetByLogin(string login)
        {
            return lstUsuarios.FirstOrDefault(x => x.Email == login);
        }

        public int GetCount()
        {
            return lstUsuarios.Count();
        }

        public Usuario Update(Usuario item)
        {
            var i = lstUsuarios.FirstOrDefault(x => x.Id == item.Id);
            if (i == null) return null;

            i.Nome = item.Nome;
            i.Email = item.Email;

            return item;
        }
    }
}
