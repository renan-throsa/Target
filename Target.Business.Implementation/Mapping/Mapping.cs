using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Target.Entities.DTO;
using Target.Entities.Entities;

namespace Target.Business.Implementation.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
