using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Mapping
{
    public class CarSharingMappingProfile : Profile
    {
        public CarSharingMappingProfile()
        {
            //CarSharing
            CreateMap<CarSharingModel, CarSharingModelDTO>()
                .ForMember(x => x.Location, o => o.Ignore());
            CreateMap<CarSharingModelDTO, CarSharingModel>()
                .ForMember(x => x.Location, o => o.Ignore());
            CreateMap<CarSharingModel, CreateCarSharingModelDTO>()
                .ForMember(x => x.Location, o => o.Ignore());
            CreateMap<CreateCarSharingModelDTO, CarSharingModel>()
                .ForMember(x => x.Location, o => o.Ignore());
            CreateMap<UpdateCarSharingModelDTO, CarSharingModel>()
                .ForMember(x => x.Location, o => o.Ignore());
            CreateMap<CarSharingModel, UpdateCarSharingModelDTO>()
                .ForMember(x => x.Location, o => o.Ignore());

            //RentCar
            CreateMap<RentCarModel, RentCarsModelDTO>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModelDTO() { Value = z.Price.Value }))
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<RentCarsModelDTO, RentCarModel>()
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<RentCarModel, AddRentCarDTO>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModelDTO() { Value = z.Price.Value}))
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<AddRentCarDTO, RentCarModel>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModel() { Value = z.Price.Value}))
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<RentCarModel, UpdateRentCarDTO>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModelDTO() { Value = z.Price.Value }))
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<UpdateRentCarDTO, RentCarModel>()
                .ForMember(x => x.Price, o => o.MapFrom(z => new PriceModel() { Value = z.Price.Value }))
                .ForMember(x => x.Type, o => o.Ignore());
        }
    }
}
