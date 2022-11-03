using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSysCloud.Domain.Entities
{
    public class Arquivo : EntidadeBase
    {
        public string NomeArquivo { get; set; }
        public string Key { get; set; }    
    }
}