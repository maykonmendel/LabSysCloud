using AutoMapper;
using LabSysCloud.Application.Models.PacienteModels;
using LabSysCloud.CrossCuting.S3Bucket;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using LabSysCloud.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace LabSysCloud.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly IServicoBase<Paciente> _baseServico;
        private readonly IStorageConfig _s3Bucket;
        private readonly IMapper _mapper;
        private readonly ILogger<PacienteController> _logger;

        public PacienteController(IServicoBase<Paciente> baseServico, IStorageConfig s3Bucket, IMapper mapper, ILogger<PacienteController> logger)
        {
            _baseServico = baseServico;
            _s3Bucket = s3Bucket;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<PacienteInputModel>> Post([FromForm] PacienteInputModel pacienteInputModel)
        {
            if (pacienteInputModel == null)
            {
                return NotFound();
            }

            if (pacienteInputModel.FotoArquivo != null)
            {
                var file = await _s3Bucket.UploadImageAsync(pacienteInputModel.FotoArquivo);
                pacienteInputModel.Foto = file.Key;
            }

            var paciente = await _baseServico.Adicionar<PacienteInputModel, PacienteViewModel, PacienteValidator>(pacienteInputModel);

            _logger.LogInformation("Paciente foi cadastrado com sucesso em ", DateTime.Now.ToString(), ".");

            return Ok(paciente);
        }

        [HttpPut]
        public async Task<ActionResult<PacienteInputModel>> Put([FromBody] PacienteInputModel pacienteInputModel)
        {
            if (pacienteInputModel == null)
            {
                return NotFound();
            }

            var pacienteEditado = await _baseServico.Atualizar<PacienteInputModel, PacienteViewModel, PacienteValidator>(pacienteInputModel);

            return Ok(pacienteEditado);
        }

        [HttpGet]
        public async Task<ActionResult<PacienteViewModel>> GetAll(int items = 5, int page = 1)
        {
            var query = await _baseServico.BuscarTodos<PacienteViewModel>();
            var model = PagingList.Create(query, items, page);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteViewModel>> GetById(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var pacienteSelecionado = await _baseServico.BuscarPorId<PacienteViewModel>(id);

            return Ok(pacienteSelecionado);
        }
    }
}