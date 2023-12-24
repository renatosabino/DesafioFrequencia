using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Desafios.Repository;
using DesafioFrequencia.Domain.Models.Participantes.Repository;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository;
using DesafioFrequencia.Infra.Data.Context;
using DesafioFrequencia.Infra.Data.Identity;
using DesafioFrequencia.Infra.Data.Repositories;
using DesafioFrequencia.Infra.Utils;
using DesafioFrequencia.Infra.Utils.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioFrequencia.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DesafioFrequenciaContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DesafioFrequenciaContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
            services.AddScoped<IDesafioRepository, DesafioRepository>();
            services.AddScoped<IRegistroFrequenciaRepository, RegistroFrequenciaRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IImageUploadService, ImageUploadService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            var myHandlers = AppDomain.CurrentDomain.Load("DesafioFrequencia.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));

            return services;
        }
    }
}