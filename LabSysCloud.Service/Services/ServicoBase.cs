using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;

namespace LabSysCloud.Service.Services
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

        public TEntity Adicionar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            ValidarObj(obj, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Adicionar(obj);

            return obj;
        }

        public TEntity Atualizar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            ValidarObj(obj, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Atualizar(obj);

            return obj;
        }

        public void Deletar(long id) => _baseRepositorio.Deletar(id);

        public IList<TEntity> BuscarTodos() => _baseRepositorio.BuscarTodos();

        public TEntity BuscarPorId(long id) => _baseRepositorio.BuscarPorId(id);
    }
}