using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaDentaria.Infra.Configurations
{
    public class DentistaConfiguration : IEntityTypeConfiguration<Dentista>
    {
        public void Configure(EntityTypeBuilder<Dentista> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Nome)
                .IsRequired();
            builder
                .Property(x => x.Email)
                .IsRequired();
        }
    }
}