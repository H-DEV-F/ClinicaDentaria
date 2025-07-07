using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaDentaria.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}