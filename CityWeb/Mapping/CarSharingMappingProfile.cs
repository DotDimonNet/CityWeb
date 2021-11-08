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
            CreateMap<RentCarModel, RentCarsModelDTO>();
            CreateMap<RentCarsModelDTO, RentCarModel>();
            CreateMap<RentCarModel, AddRentCarDTO>();
            CreateMap<AddRentCarDTO, RentCarModel>();
            CreateMap<RentCarModel, UpdateRentCarDTO>();
            CreateMap<UpdateRentCarDTO, RentCarModel>();
        }
    }
}
