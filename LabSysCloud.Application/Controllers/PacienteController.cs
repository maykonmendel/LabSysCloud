using AutoMapper;
using LabSysCloud.Application.Models.PacienteModels;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using LabSysCloud.Service.Validators;
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

        [HttpPost]
        public async Task<ActionResult<PacienteInputModel>> Post([FromBody] PacienteInputModel pacienteInputModel)
        {
            if(pacienteInputModel == null)
            {
                return NotFound();
            }

            var paciente = _mapper.Map<Paciente>(pacienteInputModel);

            await _baseServico.Adicionar<PacienteValidator>(paciente);

            return Ok(paciente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteViewModel>> GetById([FromBody] long id)
        {
            var paciente = await _baseServico.BuscarPorId(id);
            var pacienteViewModel = _mapper.Map<PacienteViewModel>(paciente);

            return Ok(pacienteViewModel);
        }
        
    }
}