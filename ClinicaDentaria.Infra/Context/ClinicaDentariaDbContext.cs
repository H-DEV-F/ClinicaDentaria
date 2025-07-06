using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Domain.Entities;
using ClinicaDentaria.Infra.Configurations;

namespace ClinicaDentaria.Infra.Context
{
    public class ClinicaDentariaDbContext : DbContext
    {
        public DbSet<Agenda> Paciente { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Dentista> Dentista { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public ClinicaDentariaDbContext(DbContextOptions<ClinicaDentariaDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());
            modelBuilder.ApplyConfiguration(new DentistaConfiguration());
            modelBuilder.ApplyConfiguration(new AgendaConfiguration());
            modelBuilder.ApplyConfiguration(new SalaConfiguration());
            modelBuilder.ApplyConfiguration(new Enderecoconfiguration());
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
            modelBuilder.ApplyConfiguration(new SalaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}