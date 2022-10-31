using AutoMapper;
using LabSysCloud.Application.Models.PacienteModels;
using LabSysCloud.CrossCuting.S3Bucket;
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
        public IActionResult Post([FromForm] PacienteInputModel pacienteInputModel)
        {
            if(pacienteInputModel == null)
            {
                return NotFound();
            }

            var uploadService = new S3BucketService();

            if(pacienteInputModel.Image != null)
            {
                var image = uploadService.UploadImagem(pacienteInputModel.Image);
                pacienteInputModel.Foto = image.Key;
            }

            var paciente = _baseServico.Adicionar<PacienteInputModel, PacienteViewModel, PacienteValidator>(pacienteInputModel);

            return Ok(paciente);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PacienteInputModel pacienteInputModel)
        {            
            if(pacienteInputModel == null)
            {
                return NotFound();
            }

            var pacienteEditado = _baseServico.Atualizar<PacienteInputModel, PacienteViewModel, PacienteValidator>(pacienteInputModel);

            return Ok(pacienteEditado);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pacientes = _baseServico.BuscarTodos<PacienteViewModel>();
            
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            if(id == 0) 
            {
                return NotFound();
            }

            var pacienteSelecionado = _baseServico.BuscarPorId<PacienteViewModel>(id);

            return Ok(pacienteSelecionado);
        }
        
    }
}