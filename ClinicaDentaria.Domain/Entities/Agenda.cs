using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaDentaria.Domain.Entities
{
    public class Agenda
    {
        public int Id { get; set; }
        public int DentistaId { get; set; }
        [ForeignKey("DentistaId")]
        public int SalaId { get; set; }
        [ForeignKey("SalaId")]
        public DateTime DataDisponivel { get; set; }
        [ForeignKey("PacienteId")]
        public int? PacienteId { get; set; }
    }
}
