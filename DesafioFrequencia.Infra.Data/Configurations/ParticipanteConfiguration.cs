using DesafioFrequencia.Domain.Models.Participantes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFrequencia.Infra.Data.Configurations
{
    public class ParticipanteConfiguration : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(v => v.NomeCompleto)
                .Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            builder.OwnsOne(v => v.NomeCompleto)
                .Property(x => x.Sobrenome)
                .HasColumnName("Sobrenome")
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(v => v.Sexo)
                .Property(x => x.Valor)
                .HasColumnName("Sexo")
                .HasMaxLength(10)
                .IsRequired();

            builder.OwnsOne(v => v.DataDeNascimento)
                .Property(x => x.Valor)
                .HasColumnName("DataDeNascimento")
                .IsRequired();

            builder.OwnsOne(v => v.DataDeNascimento)
                .Property(x => x.Valor)
                .HasColumnName("DataDeNascimento")
                .IsRequired();

            builder.OwnsOne(v => v.Imagem)
                .Property(x => x.Endereco)
                .HasColumnName("Imagem");
        }
    }
}
