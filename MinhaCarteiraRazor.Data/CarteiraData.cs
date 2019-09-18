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

        public IEnumerable<Carteira> GetByName(string name)
        {
            var query = from r in db.Carteiras
                        where r.Nome.StartsWith(name) || string.IsNullOrEmpty(name)
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
