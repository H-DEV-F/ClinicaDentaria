using Microsoft.Extensions.Logging;
using ClinicaDentaria.Infra.Context;
using ClinicaDentaria.Domain.Entities;
using ClinicaDentaria.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentaria.Infra.Repositories
{
    public class AgendaRepository : BaseRepository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(ClinicaDentariaDbContext circlesPratasContexto, IConfiguration config, ILogger<BaseRepository<Agenda>> logger) : base(circlesPratasContexto, config, logger)
        {
        }
    }
}