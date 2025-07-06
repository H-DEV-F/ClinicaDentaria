using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaDentaria.Infra.Configurations
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Tipo)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(14);
        }
    }
}