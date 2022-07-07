using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Target.Entities.Entities;

namespace Target.Repositories.Contract
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<int> AddAsync(TEntity entity);
        Task<TEntity> FindSync(int Id);
        Task<IEnumerable<TEntity>> AllAsync();
        Task<int> DeleteAsync(int Id);        
        Task<int> UpdateAsync(TEntity entity);        
        IQueryable<TEntity> GetQueryable();
    }
}
