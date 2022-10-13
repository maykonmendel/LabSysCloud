using LabSysCloud.Domain.Entities.Enums;
using LabSysCloud.Domain.Interfaces;

namespace LabSysCloud.Domain.Entities.ValueObjects
{
    public class Endereco : EntidadeBase
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Estado Estado { get; set; }
        public long PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}