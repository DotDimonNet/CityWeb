using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HouseBillDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Mapping
{
    public class HouseBillMappingProfile : Profile
    {
        public HouseBillMappingProfile()
        {


            //Address
            CreateMap<AddressModel,AddressModelDTO>();
            CreateMap<AddressModelDTO, AddressModel>();

            //Period
            CreateMap<PeriodModel, PeriodModelDTO>();
            CreateMap<PeriodModelDTO, PeriodModel>();

            //Price
            CreateMap<PriceModel, PriceModelDTO>();
            CreateMap<PriceModelDTO, PriceModel>();

            //HouseBill
            CreateMap<HouseBillModel, HouseBillModelDTO>();
            CreateMap<HouseBillModelDTO, HouseBillModel>();
            CreateMap<HouseBillModel, CreateHouseBillModelDTO>();
            CreateMap<CreateHouseBillModelDTO, HouseBillModel>()
                .ForMember(x => x.Service, o => o.MapFrom(z => new ServiceModel()));
                
            CreateMap<UpdateHouseBillModelDTO, HouseBillModel>();

            CreateMap<HouseBillModel, UpdateHouseBillModelDTO>();

            //Counter
            CreateMap<CounterModel, CounterModelDTO>();

            CreateMap<CounterModelDTO, CounterModel>()
                .ForMember(x => x.BillType, o => o.MapFrom(z => Enum.Parse<HouseBillType>(z.Type)));

            CreateMap<CounterModel, CreateCounterModelDTO>()
                .ForMember(x => x.Type, o => o.MapFrom(z => z.BillType.ToString()));

            CreateMap<CreateCounterModelDTO, CounterModel>()
                .ForMember(x => x.BillType, o => o.MapFrom(z => Enum.Parse<HouseBillType>(z.Type)));

            CreateMap<CounterModel, UpdateCounterModelDTO>();

            CreateMap<UpdateCounterModelDTO, CounterModel>();
        }
    }
}
