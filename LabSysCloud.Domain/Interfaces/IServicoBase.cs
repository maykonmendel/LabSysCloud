using FluentValidation;
using LabSysCloud.Domain.Entities;
namespace LabSysCloud.Domain.Interfaces
{
    public interface IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        // Task<TEntity> Adicionar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        // Task<TEntity> Atualizar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        // Task Deletar(long id);
        // Task<List<TEntity>> BuscarTodos();
        // Task<TEntity> BuscarPorId(long id);

        Task<TOutputModel> Adicionar<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        Task<TOutputModel> Atualizar<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        Task<IEnumerable<TOutputModel>> BuscarTodos<TOutputModel>() where TOutputModel : class;

        Task<TOutputModel> BuscarPorId<TOutputModel>(long id) where TOutputModel : class;

        Task Deletar(long id);
    }
}