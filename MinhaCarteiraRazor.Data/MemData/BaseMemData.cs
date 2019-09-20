using Microsoft.EntityFrameworkCore;
using MinhaCarteiraRazor.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaCarteiraRazor.Data.MemData
{
    public abstract class BaseMemData<T> where T : BaseEntity
    {
        protected List<T> lst;

        public BaseMemData()
        {
            lst = new List<T>();
        }

        public T Add(T newItem)
        {
            var nid = lst.Max(x => x.Id) + 1;
            newItem.Id = nid;

            lst.Add(newItem);
            return newItem;
        }

        public int Commit()
        {
            return 1;
        }

        public T Delete(T item)
        {
            var i = lst.FirstOrDefault(x => x.Id == item.Id);
            if (i == null) return null;

            lst.Remove(i);
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return lst;
        }

        public T GetById(int id)
        {
            var r = lst.FirstOrDefault(x => x.Id == id);
            return r;
        }

        public int GetCount()
        {
            return lst.Count();
        }

        public T Update(T item)
        {
            var i = lst.FirstOrDefault(x => x.Id == item.Id);
            i = item;
            return item;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var r = await lst.AsQueryable().ToListAsync();
            return r;
        }

    }
}
