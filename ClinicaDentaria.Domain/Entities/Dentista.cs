using ClinicaDentaria.Domain.ViewModels;

namespace ClinicaDentaria.Domain.Entities
{
    public class Dentista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual List<Agenda> Agenda { get; set; }

        public static explicit operator Dentista(DentistaViewModels obj)
        {
            return new Dentista()
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Email = obj.Email,
                Agenda = new List<Agenda>()
            };
        }
    }
}