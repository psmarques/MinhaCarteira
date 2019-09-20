using System;
using System.Collections.Generic;
using MinhaCarteiraRazor.Core.Entities;
using System.Linq;

namespace MinhaCarteiraRazor.Data.MemData
{
    public class OperacaoMemData : BaseMemData<Operacao>, IOperacaoData
    {
        public OperacaoMemData() : base()
        {
            var u = new Usuario { Id = 1, Nome = "Paulo Marques", Email = "psmarques@gmail.com" };
            var u2 = new Usuario { Id = 1, Nome = "José da Silva", Email = "jsilva@gmail.com" };
            var c = new Carteira { Id = 1, Nome = "Carteira Swing", Usuario = u, Investido = 7667 };
            var c2 = new Carteira { Id = 2, Nome = "Carteira Swing", Usuario = u2, Investido = 2723 };


            lst.Add(new Operacao { Id = 1, Carteira = c, Papel = "PETR4", Data = new DateTime(2019, 09, 13), PrecoEntrada = 26.88M, PrecoGain = 50M, PrecoStop = 24M, Tipo = OperacaoTipo.Comprado });
            lst.Add(new Operacao { Id = 2, Carteira = c, Papel = "VALE3", Data = new DateTime(2019, 09, 13), PrecoEntrada = 49.79M, PrecoGain = 70M, PrecoStop = 40M, Tipo = OperacaoTipo.Comprado });

            lst.Add(new Operacao { Id = 3, Carteira = c2, Papel = "USIM5", Data = new DateTime(2019, 09, 13), PrecoEntrada = 8.13M, PrecoGain = 10M, PrecoStop = 5M, Tipo = OperacaoTipo.Comprado });
            lst.Add(new Operacao { Id = 4, Carteira = c2, Papel = "ABEV3", Data = new DateTime(2019, 09, 13), PrecoEntrada = 19.05M, PrecoGain = 40M, PrecoStop = 14M, Tipo = OperacaoTipo.Comprado });
        }

        public IEnumerable<Operacao> GetAll(int userId)
        {
            var r = from item in lst
                    where item.Carteira.Usuario.Id == userId
                    select item;

            return r;
        }
    }
}
