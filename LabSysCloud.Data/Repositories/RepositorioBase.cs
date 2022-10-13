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
        }

        public virtual void Atualizar(TEntity obj)
        {
            _context.Set<TEntity>().Update(obj);
        }

        public virtual async Task<TEntity> BuscarPorId(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> BuscarTodos()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual void Excluir(long id)
        {
            TEntity entityToDelete = _context.Set<TEntity>().Find(id);

            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}