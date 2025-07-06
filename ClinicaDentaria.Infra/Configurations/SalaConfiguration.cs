using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaDentaria.Infra.Configurations
{
    public class SalaConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}