namespace ClinicaDentaria.Domain.Entities
{
    public class InfoAgendamento : Agenda
    {
        public int AgendaId { get; set; }
        public DateTime DtDisponivel { get; set; }
        public int DtId { get; set; }
        public string NomeDentista { get; set; }
    }
}
