using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.Domain.Models.Participantes;
using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using Microsoft.EntityFrameworkCore;

namespace DesafioFrequencia.Infra.Data.Context
{
    public class DesafioFrequenciaContext : DbContext
    {
        public DesafioFrequenciaContext(DbContextOptions options) : base(options) { }

        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Desafio> Desafios { get; set; }
        public DbSet<RegistroFrequencia> RegistroFrequencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioFrequenciaContext).Assembly);
        }
    }
}
