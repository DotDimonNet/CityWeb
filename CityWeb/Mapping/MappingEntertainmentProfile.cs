using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;

namespace CityWeb.Mapping
{
    public class MappingEntertainmentProfile : Profile
    {
        public MappingEntertainmentProfile()
        {

            //Price
            CreateMap<PriceModel, PriceModelDTO>();
            CreateMap<PriceModelDTO, PriceModel>();

            //Address
            CreateMap<AddressModel, AddressModelDTO>();
            CreateMap<AddressModelDTO, AddressModel>();

            CreateMap<EntertainmentModel, EntertainmentModelDTO>();

            CreateMap<EntertainmentModelDTO, EntertainmentModel>();

            CreateMap<EventModel, EventModelDTO>();

            CreateMap<UpdateEntertainmentDTO, EntertainmentModel>();

            CreateMap<UpdateEventDTO, EventModel>();

            CreateMap<AddEntertainmentModelDTO, EntertainmentModel>();

            CreateMap<AddEventModelDTO, EventModel>();
                







        }
    }
}
