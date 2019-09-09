using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Data
{
    public interface IBaseData<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Update(T carteira);

        T Add(T newCarteira);

        T Delete(T carteira);

        int GetCount();

        int Commit();

    }
}
