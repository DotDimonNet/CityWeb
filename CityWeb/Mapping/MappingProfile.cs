using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeliveryModel, DeliveryModelDTO>()
                .ForMember(x => x.Description, o => o.MapFrom(z => z.Description))
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Title));
        }
    }
}
