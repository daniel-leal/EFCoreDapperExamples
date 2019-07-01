using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExemplosEFCore
{
    public class RegiaoMap : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.HasKey(e => e.IdRegiao);

            builder.Property(e => e.IdRegiao).ValueGeneratedNever();

            builder.Property(e => e.NomeRegiao)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);


            // SEED DATABASE
            //builder.HasData(
            //    new { NomeRegiao = "Norte" },
            //    new { NomeRegiao = "Nordeste" },
            //    new { NomeRegiao = "Centro-Oeste" },
            //    new { NomeRegiao = "Sul" },
            //    new { NomeRegiao = "Sudeste" });
        }
    }
}
