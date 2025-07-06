using Microsoft.Extensions.Logging;
using ClinicaDentaria.Infra.Context;
using ClinicaDentaria.Domain.Entities;
using ClinicaDentaria.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentaria.Infra.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ClinicaDentariaDbContext clinicaDentariaDbContext, IConfiguration config, ILogger<BaseRepository<Paciente>> logger) : base(clinicaDentariaDbContext, config, logger)
        {
        }
    }
}