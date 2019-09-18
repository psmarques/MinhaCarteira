using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCarteiraRazor.Data.MemData
{
    public class CarteiraMemData : ICarteiraData
    {
        private List<Carteira> lst;

        public CarteiraMemData()
        {
            var u = new Usuario { Id = 1, Nome = "Paulo Marques", Email = "psmarques@gmail.com" };
            var u2 = new Usuario { Id = 1, Nome = "José da Silva", Email = "jsilva@gmail.com" };

            lst = new List<Carteira>();
            lst.Add(new Carteira { Id = 1, Nome = "Carteira FII", Usuario = u, Investido = 2000, Atual = 2200 });
            lst.Add(new Carteira { Id = 2, Nome = "Carteira Swing", Usuario = u, Investido = 1500, Atual = 1900 });
            lst.Add(new Carteira { Id = 3, Nome = "Carteira Buy Hold", Usuario = u, Investido = 1000, Atual = 1900 });

            lst.Add(new Carteira { Id = 4, Nome = "Carteira Swing", Usuario = u2, Investido = 3000, Atual = 4600 });
        }

        public IEnumerable<Carteira> GetAll()
        {
            var r = from item in this.lst
                    orderby item.Nome
                    select item;

            return r;
        }

        public IEnumerable<Carteira> GetByName(string name)
        {
            var r = from item in this.lst
                    orderby item.Nome
                    where item.Nome.StartsWith(name, StringComparison.OrdinalIgnoreCase)
                    select item;

            return r;
        }

        public Carteira GetById(int id)
        {
            return lst.SingleOrDefault(x => x.Id == id);
        }

        public Carteira Update(Carteira carteira)
        {
            var item = lst.SingleOrDefault(x => x.Id == carteira.Id);

            if (carteira != null)
            {
                item.Nome = carteira.Nome;
                item.Atual = carteira.Atual;
                item.Investido = carteira.Investido;
            }

            return item;
        }

        public Carteira Add(Carteira newCarteira)
        {
            newCarteira.Id = lst.Max(x => x.Id) + 1;
            lst.Add(newCarteira);

            return newCarteira;
        }

        public Carteira Delete(Carteira carteira)
        {
            var item = lst.SingleOrDefault(x => x.Id == carteira.Id);

            if (carteira != null)
            {
                lst.Remove(item);
            }

            return item;
        }

        public int GetCount()
        {
            return lst.Count;
        }

        public int Commit()
        {
            return 1;
        }

        public IEnumerable<Carteira> GetTop5()
        {
            return lst.OrderByDescending(x => (x.Investido / x.Atual)).Take(5);
        }
    }
}
