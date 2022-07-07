using System.Collections.Generic;
using Target.Entities.Entities;

namespace Target.Repositories.Contract
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Browse(string filter);
    }
}
