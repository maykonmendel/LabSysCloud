using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabSysCloud.Application.Models.UsuarioModels;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabSysCloud.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IServicoBase<Usuario> _baseServico;
        private readonly IMapper _mapper;

        public LoginController(IServicoBase<Usuario> baseServico, IMapper mapper)
        {
            _baseServico = baseServico;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UsuarioInputModel usuarioInputModel)
        {
            var usuario = _baseServico.BuscarPorCondicao(usuarioInputModel.NomeUsuario, usuarioInputModel.Senha);
        }
    }
}