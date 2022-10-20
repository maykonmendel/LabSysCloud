using LabSysCloud.Domain.Entities.Enums;
using LabSysCloud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabSysCloud.Domain.Entities.ValueObjects
{
    [Owned]
    public class Endereco
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Estado Estado { get; set; }        
    }
}