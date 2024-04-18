using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.Domain.Models.Participantes;
using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using DesafioFrequencia.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesafioFrequencia.Infra.Data.Context
{
    public class DesafioFrequenciaContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public DesafioFrequenciaContext(DbContextOptions<DesafioFrequenciaContext> options,
            IConfiguration configuration) : base(options)
        {
            this._configuration = configuration;
        }

        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Desafio> Desafios { get; set; }
        public DbSet<RegistroFrequencia> RegistroFrequencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioFrequenciaContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DesafioFrequencia");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
