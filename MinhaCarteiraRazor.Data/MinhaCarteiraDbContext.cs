using Microsoft.EntityFrameworkCore;
using MinhaCarteiraRazor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Data
{
    public class MinhaCarteiraDbContext : DbContext
    {
        public MinhaCarteiraDbContext(DbContextOptions<MinhaCarteiraDbContext> options) : base(options)
        {

        }

        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Usuario> Usuarios { get;set; }
        public DbSet<Operacao> Operacoes { get; set; }

    }
}
