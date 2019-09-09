using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Data
{
    public interface IOperacaoData : IBaseData<Operacao>
    {

    }

    public class OperacaoData : BaseData<Operacao>, IOperacaoData
    {
        public OperacaoData(MinhaCarteiraDbContext db)
        {
            this.db = db;
        }
    }
}
