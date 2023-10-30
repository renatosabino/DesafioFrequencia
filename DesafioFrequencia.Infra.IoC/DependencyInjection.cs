using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Participantes.Repository;
using DesafioFrequencia.Infra.Data.Context;
using DesafioFrequencia.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioFrequencia.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DesafioFrequenciaContext>(options =>
                options.UseSqlite($"Data Source={GetDataSource()}",
                    b => b.MigrationsAssembly(typeof(DesafioFrequenciaContext).Assembly.FullName)));

            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var myHandlers = AppDomain.CurrentDomain.Load("DesafioFrequencia.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));

            return services;
        }

        private static string GetDataSource()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return Path.Join(path, "desafio_frequencia.db");
        }
    }
}