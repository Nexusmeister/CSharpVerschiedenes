using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Extensions;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(x => x.UnitOfMeasurement, y => y.MapFrom(x => x.UnitOfMeasurement.GetStringValue()));
        }
    }
}
