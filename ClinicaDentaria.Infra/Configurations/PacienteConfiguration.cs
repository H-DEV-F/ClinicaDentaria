using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaDentaria.Infra.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired();
            builder.Property(x => x.Email)
                .IsRequired();
        }
    }
}