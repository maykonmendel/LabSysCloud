using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LabSysCloud.Domain.Entities;

namespace LabSysCloud.Domain.Interfaces
{
    public interface IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        TEntity Adicionar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        TEntity Atualizar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Deletar(long id);
        IList<TEntity> BuscarTodos();
        TEntity BuscarPorId(long id);
    }    
}