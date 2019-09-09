using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MinhaCarteiraRazor.Data
{
    public interface IUsuarioData : IBaseData<Usuario>
    {
        Usuario GetByLogin(string login);
    }

    public class UsuarioData : BaseData<Usuario>, IUsuarioData
    {
        public UsuarioData(MinhaCarteiraDbContext db)
        {
            this.db = db;
        }

        public Usuario GetByLogin(string login)
        {
            return db.Usuarios.FirstOrDefault(x => string.Equals(x.Email, login, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
