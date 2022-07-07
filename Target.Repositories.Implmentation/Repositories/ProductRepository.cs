using System;
using System.Collections.Generic;
using Target.Entities.Entities;
using Target.Repositories.Contract;
using Target.Repositories.Implementation.Context;

namespace Target.Repositories.Implementation.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Product> Browse(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
