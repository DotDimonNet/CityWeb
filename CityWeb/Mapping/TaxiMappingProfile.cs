using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;

namespace CityWeb.Mapping
{
    public class TaxiMappingProfile : Profile
    {
        public TaxiMappingProfile()
        {
            //Taxi
            CreateMap<TaxiModel, TaxiModelDTO>();
            CreateMap<TaxiModelDTO, TaxiModel>();
            CreateMap<TaxiModel, CreateTaxiModelDTO>();
            CreateMap<CreateTaxiModelDTO, TaxiModel>();
            CreateMap<UpdateTaxiModelDTO, TaxiModel>();
            CreateMap<TaxiModel, UpdateTaxiModelDTO>();
            CreateMap<UpdateTaxiModelDTO, TaxiModel>()
                .ForMember(x => x.Title, o => o.Ignore());

            //TaxiCar
            CreateMap<TaxiCarModel, TaxiCarModelDTO>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModelDTO() { Value = z.Price.Value }))
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<TaxiCarModelDTO, TaxiCarModel>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModel() { Value = z.Price.Value }))
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<AddTaxiCarDTO, TaxiCarModel>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModel() { Value = z.Price.Value }))
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<UpdateTaxiCarDTO, TaxiCarModel>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModel() { Value = z.Price.Value }))
                .ForMember(x => x.Type, o => o.Ignore());
        }
    }
}
