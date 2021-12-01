using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Domain.Interfaces.Repositories;
using UserManagement.Infra.Data.Context;

namespace UserManagement.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await Task.Run(() => _dbSet.AddAsync(obj));
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            var result = await Task.Run(() => _dbSet.Update(obj));
            return result.Entity;
        }


        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Task.Run(() => _dbSet);
        }

        public virtual void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
