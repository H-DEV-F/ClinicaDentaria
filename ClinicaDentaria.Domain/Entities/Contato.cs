using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaDentaria.Domain.Entities
{
    public class Contato
    {
        public Guid Id { get; set; }
        public Paciente Paciente { get; set; }
        public char Tipo { get; set; }
        public string Telefone { get; set; }
    }
}