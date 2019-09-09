using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Hash { get; set; }

    }
}
