using ClinicaDentaria.Domain.ViewModels;

namespace ClinicaDentaria.Domain.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        public static explicit operator Sala(SalaViewModels obj)
        {
            return new Sala()
            {
                Id = obj.Id,
                Numero = obj.Numero
            };
        }
    }
}