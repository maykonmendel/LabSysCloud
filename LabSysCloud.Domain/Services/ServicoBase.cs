using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;

namespace LabSysCloud.Domain.Services
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        private readonly IRepositorioBase<TEntity> _baseRepositorio;

        public ServicoBase(IRepositorioBase<TEntity> baseRepositorio)
        {
            _baseRepositorio = baseRepositorio;
        }

        private void ValidarObj(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null) throw new Exception("Registro não encontrado!");
            validator.ValidateAndThrow(obj);
        }

        public async Task<TEntity> Adicionar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            ValidarObj(obj, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Adicionar(obj);

            await _baseRepositorio.SaveChangesAsync();

            return obj;
        }

        public async Task<TEntity> Atualizar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            ValidarObj(obj, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Atualizar(obj);

            await _baseRepositorio.SaveChangesAsync();

            return obj;
        }

        public async Task Deletar(long id)
        {
            _baseRepositorio.Excluir(id);

            await _baseRepositorio.SaveChangesAsync();
        }

        public async Task<List<TEntity>> BuscarTodos()
        {
            var listaEntidades = await _baseRepositorio.BuscarTodos();

            return  listaEntidades;
        }

        public async Task<TEntity> BuscarPorId(long id)
        {
            var entidade = _baseRepositorio.BuscarPorId(id);

            return await entidade;
        }
    }
}