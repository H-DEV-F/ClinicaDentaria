using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Models;

namespace ClinicaDentaria.Data
{
    public class ClinicaDentariaContext : DbContext
    {
        public ClinicaDentariaContext (DbContextOptions<ClinicaDentariaContext> options)
            : base(options)
        {
        }

        public DbSet<ClinicaDentaria.Models.Paciente> Paciente { get; set; }
        public DbSet<ClinicaDentaria.Models.Contato> Contato { get; set; }
        public DbSet<ClinicaDentaria.Models.Endereco> Endereco { get; set; }
        public DbSet<ClinicaDentaria.Models.Dentista> Dentista { get; set; }
        public DbSet<ClinicaDentaria.Models.Sala> Sala { get; set; }
        public DbSet<ClinicaDentaria.Models.Agenda> Agenda { get; set; }
    }
}
