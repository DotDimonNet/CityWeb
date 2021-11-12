using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;

namespace CityWeb.Mapping
{
    public class TaxiMappingProfile : Profile
    {
        public TaxiMappingProfile()
        {
            //Price
            CreateMap<PriceModel, PriceModelDTO>();
            CreateMap<PriceModelDTO, PriceModel>();

            //Address
            CreateMap<AddressModel, AddressModelDTO>();
            CreateMap<AddressModelDTO, AddressModel>();

            //Taxi
            CreateMap<TaxiModel, TaxiModelDTO>();
            CreateMap<TaxiModelDTO, TaxiModel>();
            CreateMap<TaxiModel, CreateTaxiModelDTO>();
            CreateMap<CreateTaxiModelDTO, TaxiModel>();
            CreateMap<UpdateTaxiModelDTO, TaxiModel>();
            CreateMap<TaxiModel, UpdateTaxiModelDTO>();
            CreateMap<UpdateTaxiModelDTO, TaxiModel>();

            //TaxiCar
            CreateMap<TaxiCarModel, TaxiCarModelDTO>()
                .ForMember(x => x.Type, o => o.MapFrom(z => z.Type.ToString()));
            CreateMap<TaxiCarModelDTO, TaxiCarModel>()
                .ForMember(x => x.Type, o => o.MapFrom(z => Enum.Parse<TransportType>(z.Type)));
            CreateMap<AddTaxiCarDTO, TaxiCarModel>()
                .ForMember(x => x.Type, o => o.MapFrom(z => Enum.Parse<TransportType>(z.Type)));
            CreateMap<UpdateTaxiCarDTO, TaxiCarModel>()
                .ForMember(x => x.Type, o => o.MapFrom(z => Enum.Parse<TransportType>(z.Type)));
        }
    }
}
