using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabSysCloud.Application.Models.LoginModels;
using LabSysCloud.Application.Models.PacienteModels;
using LabSysCloud.Application.Models.UsuarioModels;
using LabSysCloud.Domain.Entities;

namespace LabSysCloud.Application.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PacienteInputModel, Paciente>();
            CreateMap<Paciente, PacienteViewModel>();

            CreateMap<UsuarioInputModel, Usuario>();
            CreateMap<Usuario, UsuarioViewModel>();            
        }
    }
}