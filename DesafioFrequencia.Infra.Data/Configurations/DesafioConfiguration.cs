using DesafioFrequencia.Domain.Models.Desafios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFrequencia.Infra.Data.Configurations
{
    public class DesafioConfiguration : IEntityTypeConfiguration<Desafio>
    {
        public void Configure(EntityTypeBuilder<Desafio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.OwnsOne(p => p.Periodo)
                .Property(p => p.Inicio)
                .HasColumnName("Inicio")
                .IsRequired();

            builder.OwnsOne(p => p.Periodo)
                .Property(p => p.Fim)
                .HasColumnName("Fim")
                .IsRequired();

            builder.OwnsOne(p => p.Regra)
                .Property(p => p.QuantidadeDiasObrigatorio)
                .HasColumnName("QuantidadeDiasObrigatorio")
                .IsRequired();

            builder.OwnsOne(p => p.Regra)
                .Property(p => p.InicioDaSemana)
                .HasColumnName("InicioDaSemana")
                .IsRequired();

            builder.HasMany(s => s.Participantes)
                .WithMany(s => s.Desafios)
                .UsingEntity(j => j.ToTable("DesafioParticipantes"));
        }
    }
}
