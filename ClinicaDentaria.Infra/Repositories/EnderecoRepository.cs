using Microsoft.Extensions.Logging;
using ClinicaDentaria.Infra.Context;
using ClinicaDentaria.Domain.Entities;
using ClinicaDentaria.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentaria.Infra.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ClinicaDentariaDbContext circlesPratasContexto, IConfiguration config, ILogger<BaseRepository<Endereco>> logger) : base(circlesPratasContexto, config, logger)
        {
        }
    }
}