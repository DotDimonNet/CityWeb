using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HousePayDTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Mapping
{
    public class HousePayMappingProfile : Profile
    {
        public HousePayMappingProfile()
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

            //HousePay
            CreateMap<HousePayModel, HousePayModelDTO>();
            CreateMap<HousePayModelDTO, HousePayModel>();
            CreateMap<HousePayModel, CreateHousePayModelDTO>();
            CreateMap<CreateHousePayModelDTO, HousePayModel>()
                .ForMember(x => x.HouseHoldAdress, o => o.Ignore());
            CreateMap<UpdateHousePayModelDTO, HousePayModel>()
                .ForMember(x => x.Title, o => o.Ignore())
                .ForMember(x => x.HouseHoldAdress, o => o.Ignore());
            CreateMap<HousePayModel, UpdateHousePayModelDTO>();

            //Counter
            CreateMap<CounterModel, CounterModelDTO>();
            CreateMap<CounterModelDTO, CounterModel>();
            CreateMap<CounterModel, CreateCounterModelDTO>()
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<CreateCounterModelDTO, CounterModel>();
             
            CreateMap<CounterModelDTO, UpdateCounterModelDTO>();
            CreateMap<UpdateCounterModelDTO, CounterModelDTO>();
        }
    }
}
