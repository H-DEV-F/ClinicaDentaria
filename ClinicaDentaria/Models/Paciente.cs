using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDentaria.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual List<Contato> Contato { get; set; }
        public virtual List<Agenda> Agenda { get; set; }
    }
}
