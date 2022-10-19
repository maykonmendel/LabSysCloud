using LabSysCloud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabSysCloud.Domain.Entities.ValueObjects
{
    [Owned]
    public class Contato
    {        
        public string Email { get; set; }
        public int DDDResidencial { get; set; }
        public string TelefoneResidencial { get; set; }
        public int DDDCelular { get; set; }
        public string Celular { get; set; }
    }
}