using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaDentaria.Infra.Configurations
{
    internal class Enderecoconfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Logradouro)
                .IsRequired();
            builder.Property(e => e.Numero)
                .IsRequired();
            builder.Property(e => e.Bairro)
                .IsRequired();
            builder.Property(e => e.Cidade)
                .IsRequired();
            builder.Property(e => e.Estado)
                .IsRequired();
            builder.Property(e => e.CEP)
                .IsRequired();
        }
    }
}