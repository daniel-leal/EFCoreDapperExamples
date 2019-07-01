using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExemplosEFCore
{
    public class ExemploEFCoreContext : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Regiao> Regioes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new RegiaoMap());

            // Seed Database
            //modelBuilder.Entity<Regiao>().HasData(
            //    new { NomeRegiao = "Norte" }, 
            //    new { NomeRegiao = "Nordeste" },
            //    new { NomeRegiao = "Centro-Oeste" },
            //    new { NomeRegiao = "Sul" },
            //    new { NomeRegiao = "Sudeste" });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ExemplosEFCore;Trusted_Connection=True;");
        }
    }
}
