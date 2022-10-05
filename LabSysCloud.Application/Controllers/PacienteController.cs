using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using LabSysCloud.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LabSysCloud.Application.Controllers
{
    [Route("[controller]")]   
    public class PacienteController : Controller
    {
        private IServicoBase<Paciente> _baseServico;

        public PacienteController(IServicoBase<Paciente> baseServico)
        {
            _baseServico = baseServico;
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Paciente paciente)
        {
            if(paciente == null)
            {
                return NotFound();
            }           

            return Execute(() => _baseServico.Adicionar<PacienteValidator>(paciente).Id);
        }

        [HttpPut("{id}")]
        public IActionResult Put ([FromBody] Paciente paciente)
        {
            if(paciente == null)
            {
                return NotFound();
            }

            return Execute(() => _baseServico.Atualizar<PacienteValidator>(paciente));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (long id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            return Execute(() =>
            {
                _baseServico.Deletar(id);
                return new NoContentResult();
            });            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Execute(() => _baseServico.BuscarTodos());
        }

        [HttpGet("{id")]
        public IActionResult GetById(long id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            return Execute(() => _baseServico.BuscarPorId(id));
        }
    }
}