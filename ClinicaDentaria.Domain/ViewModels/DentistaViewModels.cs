using ClinicaDentaria.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClinicaDentaria.Domain.ViewModels
{
    public class DentistaViewModels
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
        public virtual List<Agenda> Agenda { get; set; }
    }
}