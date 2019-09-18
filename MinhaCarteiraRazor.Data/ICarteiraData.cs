using MinhaCarteiraRazor.Core.Entities;
using System.Collections.Generic;

namespace MinhaCarteiraRazor.Data
{
    public interface ICarteiraData : IBaseData<Carteira>
    {
        IEnumerable<Carteira> GetByName(string name);

        IEnumerable<Carteira> GetTop5();
    }
}
