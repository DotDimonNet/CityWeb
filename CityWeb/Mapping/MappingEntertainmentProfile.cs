using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;

namespace CityWeb.Mapping
{
    public class MappingEntertainmentProfile : Profile
    {
        public MappingEntertainmentProfile()
        {
            CreateMap<EntertainmentModel, EntertainmentModelDTO>()
                .ForMember(x => x.EntertainmentTitle, o => o.MapFrom(y => y.Title))
                .ForMember(x => x.Type, o => o.Ignore())
                .ForMember(x => x.Location, o => o.Ignore());

            CreateMap<EntertainmentModelDTO, EntertainmentModel>()
                .ForMember(x => x.EntertainmentType, o => o.Ignore())
                .ForMember(x => x.Address, o => o.Ignore());

            CreateMap<EventModel, EventModelDTO>()
                .ForMember(x => x.EventTitle, o => o.MapFrom(y => y.Title))
                .ForMember(x => x.EventPrice, o => o.Ignore());

            CreateMap<UpdateEntertainmentDTO, EntertainmentModel>()
                .ForMember(x => x.EntertainmentType, o => o.Ignore())
                .ForMember(x => x.Address, o => o.Ignore())
                .ForMember(x => x.Title, o => o.Ignore());

            CreateMap<UpdateEventDTO, EventModel>()
                .ForMember(x => x.Title, o => o.MapFrom(y => y.EventTitle))
                .ForMember(x => x.EventPrice, o => o.Ignore());

            CreateMap<AddEntertainmentModelDTO, EntertainmentModel>()
                .ForMember(x => x.Title, o => o.MapFrom(y => y.EntertainmentTitle))
                .ForMember(x => x.EntertainmentType, o => o.Ignore())
                .ForMember(x => x.Address, o => o.Ignore());

            CreateMap<AddEventModelDTO, EventModel>()
                .ForMember(x => x.Title, o => o.MapFrom(y => y.EventTitle))
                .ForMember(x => x.EventPrice, o => o.Ignore());
            
                







        }
    }
}
