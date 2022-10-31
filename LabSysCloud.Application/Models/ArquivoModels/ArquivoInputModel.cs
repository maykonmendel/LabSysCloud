using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSysCloud.Application.Models.ArquivoModels
{
    public class ArquivoInputModel
    {
        public IFormFile Arquivo { get; set; }
        public string NomeArquivo { get; set; }
        public string Key { get; set; }
    }
}