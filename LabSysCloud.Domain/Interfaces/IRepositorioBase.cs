using LabSysCloud.Domain.Entities;

namespace LabSysCloud.Domain.Interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(long id);        
        IList<TEntity> BuscarTodos();
        TEntity BuscarPorId(long id);              
    }
}