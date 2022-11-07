using AutoMapper;
using FluentValidation;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;

namespace LabSysCloud.Service.Services
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        private readonly IRepositorioBase<TEntity> _baseRepositorio;
        private readonly IMapper _mapper;

        public ServicoBase(IRepositorioBase<TEntity> baseRepositorio, IMapper mapper)
        {
            _baseRepositorio = baseRepositorio;
            _mapper = mapper;
        }

        private void ValidarObj(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null) throw new Exception("Registro não encontrado!");
            validator.ValidateAndThrow(obj);
        }

        public async Task<TOutputModel> Adicionar<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            ValidarObj(entity, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Adicionar(entity);
            await _baseRepositorio.SaveChangesAsync();

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public async Task<TOutputModel> Atualizar<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            ValidarObj(entity, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Atualizar(entity);
            await _baseRepositorio.SaveChangesAsync();

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public async Task Deletar(long id)
        {
            _baseRepositorio.Excluir(id);
            await _baseRepositorio.SaveChangesAsync();
        }

        public async Task<IEnumerable<TOutputModel>> BuscarTodos<TOutputModel>() where TOutputModel : class
        {
            var entities = await _baseRepositorio.BuscarTodos();
            var outputModel = entities.Select(s => _mapper.Map<TOutputModel>(s));

            return outputModel;
        }

        public async Task<TOutputModel> BuscarPorId<TOutputModel>(long id) where TOutputModel : class
        {
            var entity = await _baseRepositorio.BuscarPorId(id);
            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }
    }
}