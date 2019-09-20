using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinhaCarteiraRazor.Core.Entities
{
    public class Operacao : BaseEntity
    {
        [Required]
        public Carteira Carteira { get; set; }

        [Required]
        public OperacaoTipo Tipo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required, StringLength(50)]
        public string Papel { get; set; }

        [Required]
        public decimal PrecoEntrada { get; set; }

        public decimal PrecoStop { get; set; }

        public decimal PrecoGain { get; set; }

        public decimal Resultado { get; set; }

    }
}
