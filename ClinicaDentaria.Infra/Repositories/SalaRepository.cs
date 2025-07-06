using Microsoft.Extensions.Logging;
using ClinicaDentaria.Infra.Context;
using ClinicaDentaria.Domain.Entities;
using ClinicaDentaria.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentaria.Infra.Repositories
{
    public class SalaRepository : BaseRepository<Sala>, ISalaRepository
    {
        public SalaRepository(ClinicaDentariaDbContext circlesPratasContexto, IConfiguration config, ILogger<BaseRepository<Sala>> logger) : base(circlesPratasContexto, config, logger)
        {
        }
    }
}
