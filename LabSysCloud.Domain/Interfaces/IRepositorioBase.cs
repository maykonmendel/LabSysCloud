using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSysCloud.Domain.Entities;

namespace LabSysCloud.Domain.Interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Deletar(long id);
        IList<TEntity> BuscarTodos();
        TEntity BuscarPorId(long id);
    }
}