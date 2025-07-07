using ClinicaDentaria.Domain.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaDentaria.Domain.Entities
{
    public class Agenda
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public virtual Dentista Dentista { get; set; }
        public int SalaId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public bool Disponivel { get; set; }

        public static explicit operator Agenda(AgendaViewModels obj)
        {
            return new Agenda()
            {
                Data = obj.Data,
                Disponivel = obj.Disponivel
            };
        }
    }
}