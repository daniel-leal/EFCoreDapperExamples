using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExemplosEFCore
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(e => e.SiglaEstado);

            builder.Property(e => e.SiglaEstado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.NomeCapital)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.NomeEstado)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(d => d.Regiao)
                .WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdRegiao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estado_Regiao");
        }
    }
}
