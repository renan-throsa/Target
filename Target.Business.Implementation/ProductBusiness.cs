using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Target.Business.Contract;
using Target.Business.Implementation.Validations;
using Target.Entities.DTO;
using Target.Entities.Entities;
using Target.Repositories.Contract;

namespace Target.Business.Implementation
{
    public class ProductBusiness : BusinessCrud<Product, ProductDTO>, IProductBusinness
    {
        public ProductBusiness(IProductRepository repository, ProductValidation validator, IMapper mapper)
            : base(repository, validator, mapper)
        {
        }
    }
}
