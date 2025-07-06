using System.ComponentModel.DataAnnotations;

namespace ClinicaDentaria.Domain.ViewModels
{
    public class EnderecoViewModels
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int PacienteId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}