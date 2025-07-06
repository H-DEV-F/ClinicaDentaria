using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Infra.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace AdmCondominio.Infra.Context
{
    public class AdmCondominioDbContextFactory : IDesignTimeDbContextFactory<ClinicaDentariaDbContext>
    {
        public ClinicaDentariaDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../ClinicaDentaria.Api");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ClinicaDentariaDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ClinicaDentariaDbContext(optionsBuilder.Options);
        }
    }
}