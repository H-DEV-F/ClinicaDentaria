using Microsoft.AspNetCore.Http;
using AdmCondominio.Api.Extensions;
using Microsoft.Extensions.Options;
using ClinicaDentaria.Infra.Context;
using ClinicaDentaria.Domain.Contracts;
using AdmCondominio.Domain.Notification;
using Swashbuckle.AspNetCore.SwaggerGen;
using ClinicaDentaria.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using AdmCondominio.Domain.Notification.Interfaces;

namespace ClinicaDentaria.Api.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ClinicaDentariaDbContext>();

            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IDentistaRepository, DentistaRepository>();
            services.AddTransient<IContatoRepository, ContatoRepository>();
            services.AddTransient<IAgendaRepository, AgendaRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<ISalaRepository, SalaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}