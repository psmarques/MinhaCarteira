using MinhaCarteiraRazor.Core.Entities;
using System.Collections.Generic;

namespace MinhaCarteiraRazor.Data
{
    public interface ICarteiraData : IBaseData<Carteira>
    {
        IEnumerable<Carteira> GetAll(int userId);

        IEnumerable<Carteira> GetByName(string name, int userId);

        IEnumerable<Carteira> GetTop5();
    }
}
