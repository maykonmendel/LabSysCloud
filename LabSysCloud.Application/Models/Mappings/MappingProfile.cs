using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabSysCloud.Application.Models.PacienteModels;
using LabSysCloud.Domain.Entities;

namespace LabSysCloud.Application.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PacienteInputModel, Paciente>();
            CreateMap<Paciente, PacienteViewModel>();            
        }
    }
}