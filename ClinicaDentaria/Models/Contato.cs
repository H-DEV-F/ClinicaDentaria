using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaDentaria.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public char Tipo { get; set; }
        public string Telefone { get; set; }
    }
}
