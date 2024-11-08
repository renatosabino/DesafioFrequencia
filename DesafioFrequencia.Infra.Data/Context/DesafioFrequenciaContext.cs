﻿using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.Domain.Models.Participantes;
using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using DesafioFrequencia.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioFrequencia.Infra.Data.Context
{
    public class DesafioFrequenciaContext : IdentityDbContext<ApplicationUser>
    {
        public string DbPath { get; }

        public DesafioFrequenciaContext(DbContextOptions<DesafioFrequenciaContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "desafio_frequencia.db");
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
            optionsBuilder.UseSqlite($"Data Source={DbPath}",
                b => b.MigrationsAssembly(typeof(DesafioFrequenciaContext).Assembly.FullName));
        }
    }
}
