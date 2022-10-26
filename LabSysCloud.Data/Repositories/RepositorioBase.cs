using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSysCloud.Data.Context;
using LabSysCloud.Domain.Entities;
using LabSysCloud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabSysCloud.Data.Repositories
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        protected readonly ApplicationDbContext _context;

        public RepositorioBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void Adicionar(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public virtual void Atualizar(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Set<TEntity>().Update(obj);
            _context.SaveChanges();
        }

        public virtual TEntity BuscarPorId(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IList<TEntity> BuscarTodos()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public virtual void Excluir(long id)
        {
            TEntity entityToDelete = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
}