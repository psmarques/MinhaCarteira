﻿using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCarteiraRazor.Data.MemData
{
    public class CarteiraMemData : BaseMemData<Carteira>, ICarteiraData
    {
        public CarteiraMemData() : base()
        {
            var u = new Usuario { Id = 1, Nome = "Paulo Marques", Email = "psmarques@gmail.com" };
            var u2 = new Usuario { Id = 1, Nome = "José da Silva", Email = "jsilva@gmail.com" };

            lst.Add(new Carteira { Id = 1, Nome = "Carteira FII", Usuario = u, Investido = 2000, Atual = 2200 });
            lst.Add(new Carteira { Id = 2, Nome = "Carteira Swing", Usuario = u, Investido = 1500, Atual = 1900 });
            lst.Add(new Carteira { Id = 3, Nome = "Carteira Buy Hold", Usuario = u, Investido = 1000, Atual = 1900 });

            lst.Add(new Carteira { Id = 4, Nome = "Carteira Swing", Usuario = u2, Investido = 3000, Atual = 4600 });
            lst.Add(new Carteira { Id = 5, Nome = "Carteira 2019", Usuario = u2, Investido = 2000, Atual = 3600 });
        }


        public IEnumerable<Carteira> GetAll(int userId)
        {
            var r = from item in this.lst
                    where item.Usuario.Id == userId
                    orderby item.Nome
                    select item;

            return r;
        }

        public IEnumerable<Carteira> GetByName(string name, int userId)
        {
            var r = from item in this.lst
                    orderby item.Nome
                    where item.Nome.StartsWith(name, StringComparison.OrdinalIgnoreCase) && item.Usuario.Id == userId
                    select item;

            return r;
        }

        public IEnumerable<Carteira> GetTop5()
        {
            return lst.OrderByDescending(x => (x.Investido > 0 ? (x.Atual / x.Investido) : 0)).Take(5);
        }
    }
}
