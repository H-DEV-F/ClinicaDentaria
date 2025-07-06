using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaDentaria.Infra.Configurations
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Data)
                .IsRequired();
            builder.Property(a => a.Disponivel);
        }
    }
}