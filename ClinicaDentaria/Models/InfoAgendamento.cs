using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDentaria.Models
{
    public class InfoAgendamento : Agenda
    {
        public int AgendaId { get; set; }
        public DateTime DtDisponivel { get; set; }
        public int DtId { get; set; }
        public string NomeDentista { get; set; }
    }
}
