using MinhaCarteiraRazor.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCarteiraRazor.Data
{
    public abstract class BaseData<T> : IBaseData<T> where T : BaseEntity
    {
        protected MinhaCarteiraDbContext db;

        public T Add(T item)
        {
            db.Add(item);
            return item;
        }

        public T Delete(T item)
        {
            var fitem = GetById(item.Id);

            if (fitem != null)
            {
                db.Remove<T>(item);
            }

            return item;
        }

        public T Update(T newItem)
        {
            var item = db.Attach<T>(newItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return newItem;
        }

        public T GetById(int id)
        {
            return db.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public int GetCount()
        {
            return db.Set<T>().Count();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
