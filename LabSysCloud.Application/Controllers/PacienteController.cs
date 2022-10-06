using AutoMapper;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using LabSysCloud.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabSysCloud.Application.Controllers
{
    [Route("[controller]")]   
    public class PacienteController : Controller
    {
        private readonly IServicoBase<Paciente> _baseServico;
        private readonly IMapper _mapper;

        public PacienteController(IServicoBase<Paciente> baseServico, IMapper mapper)
        {
            _baseServico = baseServico;
            _mapper = mapper;
        }    
        
    }
}