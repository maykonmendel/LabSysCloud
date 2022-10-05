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

        public void Adicionar(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(long id)
        {
            _context.Set<TEntity>().Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public TEntity BuscarPorId(long id) => _context.Set<TEntity>().Find(id);
        public IList<TEntity> BuscarTodos() => _context.Set<TEntity>().ToList();

    }
}