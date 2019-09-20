using System.Linq;
using MinhaCarteiraRazor.Core.Entities;

namespace MinhaCarteiraRazor.Data.MemData
{
    public class UsuarioMemData : BaseMemData<Usuario>, IUsuarioData
    {
        public UsuarioMemData() : base()
        {
            lst.Add(new Usuario { Id = 1, Nome = "Paulo Marques", Email = "psmarques@gmail.com", Hash = "AQAAAAEAACcQAAAAEG7/p27qy0OgIveUGBFcRncDwAsfFNUQW9n5TUBa0kGT3aKdWXdRfehFtxilR8IDfQ==" });
            lst.Add(new Usuario { Id = 2, Nome = "José da Silva", Email = "jsilva@gmail.com", Hash = "AQAAAAEAACcQAAAAEG7/p27qy0OgIveUGBFcRncDwAsfFNUQW9n5TUBa0kGT3aKdWXdRfehFtxilR8IDfQ==" });
            lst.Add(new Usuario { Id = 3, Nome = "Ana Marchesi", Email = "anamarchesi@gmail.com", Hash = "AQAAAAEAACcQAAAAEG7/p27qy0OgIveUGBFcRncDwAsfFNUQW9n5TUBa0kGT3aKdWXdRfehFtxilR8IDfQ==" });
            lst.Add(new Usuario { Id = 4, Nome = "João Barriga", Email = "jbarriga@gmail.com", Hash = "AQAAAAEAACcQAAAAEG7/p27qy0OgIveUGBFcRncDwAsfFNUQW9n5TUBa0kGT3aKdWXdRfehFtxilR8IDfQ==" });
        }

      
        public Usuario GetByLogin(string login)
        {
            return lst.FirstOrDefault(x => x.Email == login);
        }
    }
}
