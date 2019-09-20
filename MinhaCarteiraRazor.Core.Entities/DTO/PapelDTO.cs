using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Core.Entities.DTO
{
    public class PapelDTO
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public decimal? VariacaoPercentual { get; set; }

        public decimal? Variacao { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public decimal? Preco { get; set; }

        public decimal? Maxima { get; set; }

        public decimal? Minima { get; set; }

        public decimal? Abertura { get; set; }

        public decimal? Fechamento { get; set; }

        public string Volume { get; set; }

        public decimal FechamentoAnterior { get; set; }

    }
}
