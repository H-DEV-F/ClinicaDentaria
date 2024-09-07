using System;
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
            services.AddElmahIo(o =>
            {
                o.ApiKey = "b76edc95d42c414fab7e46ebcef840a0";
                o.LogId = new Guid("b7205ec8-b5af-45e7-99a5-531570a75232");
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "b76edc95d42c414fab7e46ebcef840a0";
                    options.LogId = new Guid("b7205ec8-b5af-45e7-99a5-531570a75232");
                    options.HeartbeatId = "171c973ba94b4c2fb02466e2097f9906";

                })
                .AddCheck("Db_Query", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "Db_Connection");

            services
                .AddHealthChecksUI()
                .AddInMemoryStorage()
                .AddSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
