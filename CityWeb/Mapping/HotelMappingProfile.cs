using AutoMapper;
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
            CreateMap<HotelModel, DeleteHotelDTO>();
        }
    }
}
