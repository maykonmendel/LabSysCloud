using FluentValidation;
using LabSysCloud.Domain.Entities;

namespace LabSysCloud.Domain.Interfaces
{
    public interface IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity> Adicionar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        Task<TEntity> Atualizar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        Task Deletar(long id);
        Task<List<TEntity>> BuscarTodos();
        Task<TEntity> BuscarPorId(long id);
    }    
}