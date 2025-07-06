using ClinicaDentaria.Domain.ViewModels;

namespace ClinicaDentaria.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual List<Contato> Contato { get; set; }
        public virtual List<Agenda> Agenda { get; set; }

        public static explicit operator Paciente(PacienteViewModels obj)
        {
            return new Paciente()
            {
                Nome = obj.Nome,
                Email = obj.Email
            };
        }
    }
}