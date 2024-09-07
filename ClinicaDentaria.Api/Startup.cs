using System;
using Microsoft.AspNetCore.Http;
using ClinicaDentaria.Api.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Infra.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaDentaria
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var environmentName = env.EnvironmentName;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();

            builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ClinicaDentariaContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), providerOptions =>
                    {
                        providerOptions.EnableRetryOnFailure();
                        providerOptions.MigrationsAssembly("ClinicaDentaria.Infra.Context");
                    }));

            services.AddIdentityConfig(Configuration);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddApiConfig();

            services.AddSwaggerConfig();

            services.AddLoggingConfig(Configuration);

            services.ResolveDependencies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseApiConfig(env);

            app.UseSwaggerConfig(provider);

            app.UseLoggingConfiguration();
        }
    }
}
