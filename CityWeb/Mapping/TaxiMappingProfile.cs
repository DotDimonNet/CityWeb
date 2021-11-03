using AutoMapper;
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

            //TaxiCar
            CreateMap<TaxiCarModel, TaxiCarModelDTO>();
            CreateMap<TaxiCarModelDTO, TaxiCarModel>();
            CreateMap<TaxiCarModel, AddTaxiCarDTO>();
            CreateMap<AddTaxiCarDTO, TaxiCarModel>();
        }
    }
}
