using AutoMapper;
using LabSysCloud.Application.Models.Paciente;

namespace LabSysCloud.Application.Models.Mappings
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<PacienteInputModel, Domain.Entities.Paciente>();
            CreateMap<Domain.Entities.Paciente, PacienteViewModel>();
        }
    }
}