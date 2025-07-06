using System.ComponentModel.DataAnnotations;

namespace ClinicaDentaria.Domain.ViewModels
{
    public class SalaViewModels
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Codigo { get; set; }
    }
}