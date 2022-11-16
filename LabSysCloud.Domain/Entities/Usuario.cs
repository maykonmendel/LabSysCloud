using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSysCloud.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}