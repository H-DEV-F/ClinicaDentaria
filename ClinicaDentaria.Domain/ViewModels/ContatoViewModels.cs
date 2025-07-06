using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaDentaria.Domain.ViewModels
{
    public class ContatoViewModels
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public char Tipo { get; set; }
        public string Telefone { get; set; }
    }
}