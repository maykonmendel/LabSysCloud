using LabSysCloud.Domain.Entities.Enums;
using LabSysCloud.Domain.Entities.ValueObjects;

namespace LabSysCloud.Application.Models.PacienteModels
{
    public class PacienteInputModel
    {
        public string Nome { get; set; }
        public Sexo? Sexo { get; set; }
        public Etnia? Etnia { get; set; }
        public EstadoCivil? EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }       
        public string Foto { get; set; }
        public string CNS { get; set; }
        public string Convenio { get; set; }
        public string PlanoSaude { get; set; }
        public int NumeroRegistro { get; set; }
        public DateTime ValidadeRegistro { get; set; }
        public Contato Contato { get; set; }       
        public Endereco Endereco { get; set; }
    }
}