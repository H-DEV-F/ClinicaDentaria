using System.ComponentModel.DataAnnotations;

namespace ClinicaDentaria.Domain.ViewModels
{
    public class AgendaViewModels
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int DentistaId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int SalaId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? PacienteId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Disponivel { get; set; }
    }
}
