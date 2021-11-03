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
            CreateMap<HotelModel, HotelDTO>();
            CreateMap<HotelDTO, HotelModel>()
                .ForMember(x => x.RentAddress, o => o.Ignore())
                .ForMember(x => x.Rooms, o => o.Ignore())
                .ForMember(x => x.Service, o => o.Ignore());
            CreateMap<RoomModel, RoomDTO>();
                //.ForMember(x => x.HotelTitle, o => o.MapFrom(z => z.Hotel.Title));
            CreateMap<RoomModel, UpdateRoomDTO>()
                .ForMember(x => x.HotelTitle, o => o.MapFrom(z => z.Hotel.Title));
            CreateMap<RoomModel, PeriodModel>();
            CreateMap<RoomModel, PriceModel>();
            CreateMap<RoomDTO, PriceDTO>();
            CreateMap<RoomModel, PriceDTO>();
            CreateMap<AddressModel, HotelAddressDTO>();
            CreateMap<HotelAddressDTO,AddressModel>();
            CreateMap<UpdateRoomDTO, RoomModel>()
                .ForMember(x => x.Price, o => o.Ignore());


        }
    }
}
