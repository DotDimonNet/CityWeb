using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

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

            CreateMap<EntertainmentModel, EntertainmentModelDTO>()
                .ForMember(x => x.Type, o => o.MapFrom(z => z.Type.ToString()));

            CreateMap<EntertainmentModelDTO, EntertainmentModel>();

            CreateMap<EventModel, EventModelDTO>();

            CreateMap<UpdateEntertainmentDTO, EntertainmentModel>()
                .ForMember(x => x.Type, o => o.MapFrom((z) => Enum.Parse<EntertainmentType>(z.Type)));

            CreateMap<UpdateEventDTO, EventModel>();

            CreateMap<AddEntertainmentModelDTO, EntertainmentModel>()
                .ForMember(x => x.Type, o => o.MapFrom((z) => Enum.Parse<EntertainmentType>(z.Type)));

            CreateMap<AddEventModelDTO, EventModel>();
                







        }
    }
}
