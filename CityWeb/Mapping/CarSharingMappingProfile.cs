using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
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
            //Price
            CreateMap<PriceModel, PriceModelDTO>();
            CreateMap<PriceModelDTO, PriceModel>();

            //Address
            CreateMap<AddressModel, AddressModelDTO>();
            CreateMap<AddressModelDTO, AddressModel>();

            //CarSharing
            CreateMap<CarSharingModel, CarSharingModelDTO>();
            CreateMap<CarSharingModelDTO, CarSharingModel>();
            CreateMap<CarSharingModel, CreateCarSharingModelDTO>();
            CreateMap<CreateCarSharingModelDTO, CarSharingModel>();
            CreateMap<UpdateCarSharingModelDTO, CarSharingModel>();
            CreateMap<CarSharingModel, UpdateCarSharingModelDTO>();

            //RentCar
            CreateMap<RentCarModel, RentCarModelDTO>()
                .ForMember(x => x.Type, o => o.MapFrom(z => z.Type.ToString()));
            CreateMap<RentCarModelDTO, RentCarModel>()
                .ForMember(x => x.Type, o => o.MapFrom(z => Enum.Parse<TransportType>(z.Type)));
            CreateMap<RentCarModel, AddRentCarDTO>()
                .ForMember(x => x.Type, o => o.MapFrom(z => z.Type.ToString()));
            CreateMap<AddRentCarDTO, RentCarModel>()
                .ForMember(x => x.Type, o => o.MapFrom(z => Enum.Parse<TransportType>(z.Type)));
            CreateMap<RentCarModel, UpdateRentCarDTO>()
                .ForMember(x => x.Type, o => o.MapFrom(z => z.Type.ToString()));
            CreateMap<UpdateRentCarDTO, RentCarModel>()
                .ForMember(x => x.Type, o => o.MapFrom(z => Enum.Parse<TransportType>(z.Type)));
        }
    }
}
