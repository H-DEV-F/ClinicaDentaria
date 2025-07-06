using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using ClinicaDentaria.Infra.Data.HealthCheck;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaDentaria.Api.Config
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("Db_Query", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "Db_Connection");

            services
                .AddHealthChecksUI()
                .AddInMemoryStorage()
                .AddSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app) => app;
    }
}