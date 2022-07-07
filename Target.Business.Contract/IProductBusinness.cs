using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Target.Entities.DTO;
using Target.Entities.Entities;

namespace Target.Business.Contract
{
    public interface IProductBusinness : IBaseBusiness<Product, ProductDTO>
    {
    }
}
