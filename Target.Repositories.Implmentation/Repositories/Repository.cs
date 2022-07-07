using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Target.Entities.Entities;
using Target.Repositories.Contract;
using Target.Repositories.Implementation.Context;

namespace Target.Repositories.Implementation.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity, new()
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var entity = await FindSync(Id);
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindSync(int Id)
        {
            var query = GetQueryable();
            query.Where(x => x.Id == Id).AsNoTracking();
            return await query.FirstAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync();
        }

    }
}
