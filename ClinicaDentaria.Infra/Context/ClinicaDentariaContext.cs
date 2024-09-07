using Microsoft.EntityFrameworkCore;

namespace ClinicaDentaria.Infra.Context
{
    public class ClinicaDentariaContext : DbContext
    {
        public ClinicaDentariaContext(DbContextOptions<ClinicaDentariaContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Paciente> Paciente { get; set; }
        public DbSet<Domain.Entities.Contato> Contato { get; set; }
        public DbSet<Domain.Entities.Endereco> Endereco { get; set; }
        public DbSet<Domain.Entities.Dentista> Dentista { get; set; }
        public DbSet<Domain.Entities.Sala> Sala { get; set; }
        public DbSet<Domain.Entities.Agenda> Agenda { get; set; }
    }
}
