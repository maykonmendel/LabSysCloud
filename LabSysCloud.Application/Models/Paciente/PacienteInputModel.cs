using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSysCloud.Domain.Entities.Enums;

namespace LabSysCloud.Application.Models.Paciente
{
    public class PacienteInputModel
    {
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public Etnia Etnia { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Foto { get; set; }
        public string CNS { get; set; }
        public string Convenio { get; set; }
        public string PlanoSaude { get; set; }
        public int NumeroRegistro { get; set; }
        public DateTime ValidadeRegistro { get; set; }
        public long ContatoId { get; set; }       
        public long EnderecoId { get; set; }        
    }
}