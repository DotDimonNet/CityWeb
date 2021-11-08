using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Mapping
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile()
        {
            //Address
            CreateMap<AddressModel, HotelAddressDTO>();
            CreateMap<HotelAddressDTO, AddressModel>();

            //Period
            CreateMap<PeriodModel, PeriodModelDTO>();
            CreateMap<PeriodModelDTO, PeriodModel>();

            //Price
            CreateMap<PriceModel, PriceModelDTO>();
            CreateMap<PriceModelDTO, PriceModel>();

            //Profile
            CreateMap<UserProfileModel, UserProfileModelDTO>();
            CreateMap<UserProfileModelDTO, UserProfileModel>();

            CreateMap<HotelModel, HotelDTO>();
            CreateMap<HotelDTO, HotelModel>();
            CreateMap<RoomDTO, RoomModel>();
            CreateMap<PriceDTO, PriceModel>();

            CreateMap<RoomModel, RoomDTO>();
                //.ForMember(x => x.HotelTitle, o => o.MapFrom(z => z.Hotel.Title));
            CreateMap<RoomModel, UpdateRoomDTO>()
                .ForMember(x => x.HotelTitle, o => o.MapFrom(z => z.Hotel.Title));
            CreateMap<RoomModel, PeriodModel>();
            CreateMap<RoomModel, PriceModel>();
            CreateMap<RoomDTO, PriceDTO>();
            CreateMap<RoomModel, PriceDTO>();

            CreateMap<UpdateRoomDTO, RoomModel>();


        }
    }
}
