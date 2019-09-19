using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MinhaCarteiraRazor.Data
{
    public interface IOperacaoData : IBaseData<Operacao>
    {

        IEnumerable<Operacao> GetAll(int userId);
    }

    public class OperacaoData : BaseData<Operacao>, IOperacaoData
    {
        public OperacaoData(MinhaCarteiraDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Operacao> GetAll(int userId)
        {
            var r = from item in this.db.Operacoes
                    where item.Carteira.Usuario.Id == userId
                    select item;

            return r;
        }
    }
}
