using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MinhaCarteiraRazor.Core.Entities;

namespace MinhaCarteiraRazor.Data
{
    public class CarteiraData : BaseData<Carteira>, ICarteiraData
    {
        public CarteiraData(MinhaCarteiraDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Carteira> GetAll(int userId)
        {
            var r = from item in db.Carteiras
                    where item.Usuario.Id == userId
                    orderby item.Nome
                    select item;

            return r;
        }

        public IEnumerable<Carteira> GetByName(string name, int userId)
        {
            var query = from r in db.Carteiras
                        where (r.Nome.StartsWith(name) || string.IsNullOrEmpty(name)) && r.Usuario.Id == userId 
                        orderby r.Nome
                        select r;

            return query;
        }

        public IEnumerable<Carteira> GetTop5()
        {
            var query = (from r in db.Carteiras
                        orderby (r.Investido / r.Atual) descending
                        select r).Take(5);

            return query;
        }
    }
}
