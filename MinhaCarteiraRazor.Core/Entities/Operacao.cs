using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Core.Entities
{
    public class Operacao : BaseEntity
    {
        public Carteira Carteira { get; set; }

        public OperacaoTipo Tipo { get; set; }

        public string Papel { get; set; }

        public decimal PrecoEntrada { get; set; }

        public decimal PrecoStop { get; set; }

        public decimal PrecoGain { get; set; }

        public decimal Resultado { get; set; }

    }
}
