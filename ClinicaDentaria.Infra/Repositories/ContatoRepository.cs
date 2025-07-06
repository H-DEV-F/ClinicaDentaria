using Microsoft.Extensions.Logging;
using ClinicaDentaria.Infra.Context;
using ClinicaDentaria.Domain.Entities;
using ClinicaDentaria.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentaria.Infra.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(ClinicaDentariaDbContext circlesPratasContexto, IConfiguration config, ILogger<BaseRepository<Contato>> logger) : base(circlesPratasContexto, config, logger)
        {
        }
    }
}