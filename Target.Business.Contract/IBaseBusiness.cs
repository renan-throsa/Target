using System.Collections.Generic;
using System.Threading.Tasks;
using Target.Entities.DTO;
using Target.Entities.Entities;

namespace Target.Business.Contract
{
    public interface IBaseBusiness<TEntity, TObject> where TEntity : IEntity where TObject : BaseDTO<TEntity>
    {
        Task<Response> AddAsync(TObject tObject);
        Task<Response> UpdateAsync(TObject tObject);
        Task<TObject> FindSync(int Id);
        Task<IEnumerable<TObject>> AllAsync();
        Task<int> DeleteAsync(int Id);

    }
}
