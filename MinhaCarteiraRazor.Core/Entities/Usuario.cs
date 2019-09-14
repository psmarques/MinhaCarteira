using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinhaCarteiraRazor.Core.Entities
{
    public class Usuario : BaseEntity
    {
        [Required, StringLength(160)]
        public string Nome { get; set; }

        [Required, StringLength(160), EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(255)]
        public string Hash { get; set; }

    }
}
