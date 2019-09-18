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

        T Update(T item);

        T Add(T newItem);

        T Delete(T item);

        int GetCount();

        int Commit();

    }
}
