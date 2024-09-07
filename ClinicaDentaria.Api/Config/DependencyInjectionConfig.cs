using ClinicaDentaria.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ClinicaDentaria.Api.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ClinicaDentariaContext>();

            //services.AddTransient<ICondominioRepository, CondominioRepository>();
            //services.AddTransient<IApartamentoRepository, ApartamentoRepository>();
            //services.AddTransient<IMoradorRepository, MoradorRepository>();
            //services.AddTransient<IBlocoRepository, BlocoRepository>();

            //services.AddScoped<INotificador, Notificador>();
            //services.AddScoped<IUser, AspNetUser>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
