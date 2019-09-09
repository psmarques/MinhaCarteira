using System;
using System.Collections.Generic;
using System.Linq;
using MinhaCarteiraRazor.Core.Entities;

namespace MinhaCarteiraRazor.Data
{
    public class CarteiraInMemoryData : ICarteiraData
    {
        private List<Carteira> lst;

        public CarteiraInMemoryData()
        {
            var u = new Usuario { Id = 1, Nome = "Paulo Marques", Email = "psmarques@gmail.com" };

            lst = new List<Carteira>();
            lst.Add(new Carteira { Id = 1, Nome = "Carteira FII", }); //Usuario = u });
            lst.Add(new Carteira { Id = 2, Nome = "Carteira Swing", });//Usuario = u });
            lst.Add(new Carteira { Id = 3, Nome = "Carteira Buy Hold", });//Usuario = u });
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
                //item.Usuario = carteira.Usuario;
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
                //item.Usuario = carteira.Usuario;
            }

            return item;
        }

        public int Commit()
        {
            return 1;
        }

        public int GetCount()
        {
            return lst.Count;
        }
    }
}
