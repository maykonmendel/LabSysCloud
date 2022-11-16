using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSysCloud.Application.Models.UsuarioModels
{
    public class UsuarioInputModel
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}