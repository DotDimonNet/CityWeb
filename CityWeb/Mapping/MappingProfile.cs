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
            //Address
            CreateMap<AddressModel, AddressModelDTO>();
            CreateMap<AddressModelDTO, AddressModel>();

            //Period
            CreateMap<PeriodModel, PeriodModelDTO>();
            CreateMap<PeriodModelDTO, PeriodModel>();

            CreateMap<PriceModel, PriceModelDTO>();
            CreateMap<PriceModelDTO, PriceModel>();

        }
    }
}
