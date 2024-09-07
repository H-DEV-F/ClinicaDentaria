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

        public Paciente() 
        {
            Endereco = new Endereco();
            Contato = new List<Contato>();
            Contato.Add(new Contato());
            Contato.Add(new Contato());
        }
    }
}
