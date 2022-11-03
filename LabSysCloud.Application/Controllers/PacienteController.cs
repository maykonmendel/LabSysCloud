using AutoMapper;
using LabSysCloud.Application.Models.PacienteModels;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using LabSysCloud.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabSysCloud.Application.Controllers
{
    [Route("api/[controller]")]   
    [ApiController]
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
        public async Task<ActionResult<PacienteInputModel>> Post([FromForm] PacienteInputModel pacienteInputModel)
        {
            if(pacienteInputModel == null)
            {
                return NotFound();
            }          

            var paciente = await _baseServico.Adicionar<PacienteInputModel, PacienteViewModel, PacienteValidator>(pacienteInputModel);

            return Ok(paciente);
        }

        [HttpPut]
        public async Task<ActionResult<PacienteInputModel>> Put([FromBody] PacienteInputModel pacienteInputModel)
        {            
            if(pacienteInputModel == null)
            {
                return NotFound();
            }

            var pacienteEditado = await _baseServico.Atualizar<PacienteInputModel, PacienteViewModel, PacienteValidator>(pacienteInputModel);

            return Ok(pacienteEditado);
        }

        [HttpGet]
        public async Task<ActionResult<PacienteViewModel>> GetAll()
        {
            var pacientes = await _baseServico.BuscarTodos<PacienteViewModel>();
            
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteViewModel>> GetById(long id)
        {
            if(id == 0) 
            {
                return NotFound();
            }

            var pacienteSelecionado = await _baseServico.BuscarPorId<PacienteViewModel>(id);

            return Ok(pacienteSelecionado);
        }
        
    }
}