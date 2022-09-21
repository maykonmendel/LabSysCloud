using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSysCloud.Domain.Entities
{
    public abstract class EntidadeBase
    {
        public virtual long Id { get; set; }
    }
}