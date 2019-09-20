using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Core.Entities.DTO
{
    public class PapelHistoricoDTO
    {
        public string Papel { get; set; }

        public string Data { get; set; }

        public decimal? Abertura { get; set; }

        public decimal? Fechamento { get; set; }

        public decimal? Maxima { get; set; }

        public decimal? Minima { get; set; }

    }
}
