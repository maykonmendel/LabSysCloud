using FluentValidation;
using LabSysCloud.Domain.Entities;
namespace LabSysCloud.Domain.Interfaces
{
    public interface IServicoBase<TEntity> where TEntity : EntidadeBase
    {
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