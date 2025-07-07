using System.ComponentModel.DataAnnotations;

namespace ClinicaDentaria.Domain.ViewModels
{
    public class AgendaViewModels
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public bool Disponivel { get; set; }
    }
}