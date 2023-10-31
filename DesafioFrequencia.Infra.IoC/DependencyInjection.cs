using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Desafios.Repository;
using DesafioFrequencia.Domain.Models.Participantes.Repository;
using DesafioFrequencia.Infra.Data.Context;
using DesafioFrequencia.Infra.Data.Repositories;
using DesafioFrequencia.Infra.Utils;
using DesafioFrequencia.Infra.Utils.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioFrequencia.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DesafioFrequenciaContext>();

            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
            services.AddScoped<IDesafioRepository, DesafioRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IImageUploadService, ImageUploadService>();

            var myHandlers = AppDomain.CurrentDomain.Load("DesafioFrequencia.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));

            return services;
        }
    }
}