using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinhaCarteiraRazor.Core.Entities
{
    public class Carteira : BaseEntity
    {
        [Required, StringLength(120)]
        public string Nome { get; set; }

        public Usuario Usuario { get; set; }

        public decimal Investido { get; set; }

        public decimal Atual { get; set; }

        public decimal Resultado
        {
            get
            {
                return Math.Round(Atual / (Investido <= 0 ? 1 : Investido) - 1, 2);
            }
        }

        public Carteira()
        {

        }


    }
}
