using Microsoft.Extensions.Logging;
using ClinicaDentaria.Infra.Context;
using ClinicaDentaria.Domain.Entities;
using ClinicaDentaria.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentaria.Infra.Repositories
{
    public class DentistaRepository : BaseRepository<Dentista>, IDentistaRepository
    {
        public DentistaRepository(ClinicaDentariaDbContext circlesPratasContexto, IConfiguration config, ILogger<BaseRepository<Dentista>> logger) : base(circlesPratasContexto, config, logger)
        {
        }
    }
}