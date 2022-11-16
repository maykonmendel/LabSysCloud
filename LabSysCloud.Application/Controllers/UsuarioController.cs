using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabSysCloud.Application.Models.UsuarioModels;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using LabSysCloud.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace LabSysCloud.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IServicoBase<Usuario> _baseServico;
        private readonly IMapper _mapper;

        public UsuarioController(IServicoBase<Usuario> baseServico, IMapper mapper)
        {
            _baseServico = baseServico;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioInputModel>> Post([FromBody] UsuarioInputModel usuarioInputModel)
        {
            if (usuarioInputModel == null)
            {
                return NotFound();
            }

            var usuario = await _baseServico.Adicionar<UsuarioInputModel, UsuarioViewModel, UsuarioValidator>(usuarioInputModel);

            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioInputModel>> Put([FromBody] UsuarioInputModel usuarioInputModel)
        {
            if (usuarioInputModel == null)
            {
                return NotFound();
            }

            var usuarioEditado = await _baseServico.Atualizar<UsuarioInputModel, UsuarioViewModel, UsuarioValidator>(usuarioInputModel);

            return Ok(usuarioEditado);
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioViewModel>> GetAll(int items = 5, int page = 1)
        {
            var query = await _baseServico.BuscarTodos<UsuarioViewModel>();
            var model = PagingList.Create(query, items, page);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> GetById(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var usuarioSelecionado = await _baseServico.BuscarPorId<UsuarioViewModel>(id);

            return Ok(usuarioSelecionado);
        }
    }
}