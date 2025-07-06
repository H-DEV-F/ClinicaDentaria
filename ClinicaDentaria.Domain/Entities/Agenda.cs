using ClinicaDentaria.Domain.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaDentaria.Domain.Entities
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int DentistaId { get; set; }
        [ForeignKey("DentistaId")]
        public int SalaId { get; set; }
        [ForeignKey("SalaId")]
        public int? PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public bool Disponivel { get; set; }

        public static explicit operator Agenda(AgendaViewModels obj)
        {
            return new Agenda()
            {
                Data = obj.Data,
                DentistaId = obj.DentistaId,
                SalaId = obj.SalaId,
                PacienteId = obj.PacienteId,
                Disponivel = obj.Disponivel
            };
        }
    }
}