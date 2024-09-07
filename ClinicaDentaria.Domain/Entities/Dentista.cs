namespace ClinicaDentaria.Domain.Entities
{
    public class Dentista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual List<Agenda> Agenda { get; set; }
    }
}
