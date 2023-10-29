using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFrequencia.Infra.Data.Configurations
{
    public class RegistroFrequenciaConfiguration : IEntityTypeConfiguration<RegistroFrequencia>
    {
        public void Configure(EntityTypeBuilder<RegistroFrequencia> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(v => v.DataFrequencia)
                .Property(x => x.Data)
                .HasColumnName("Data")
                .IsRequired();

            builder.OwnsOne(v => v.EstadoFrequencia)
                .Property(x => x.Tipo)
                .HasColumnName("Estado")
                .HasMaxLength(20)
                .IsRequired();

            builder.OwnsOne(v => v.Imagem)
                .Property(x => x.Endereco)
                .HasColumnName("Imagem")
                .HasMaxLength(100);

            builder.HasOne(f => f.Desafio)
                .WithMany(f => f.RegistroFrequencias);

            builder.HasOne(f => f.Participante)
                .WithMany(f => f.RegistroFrequencias);
        }
    }
}
