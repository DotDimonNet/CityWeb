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
                .ForMember(x => x.Description, o => o.MapFrom(y => y.Description))
                .ForMember(x => x.Type, o => o.MapFrom(y => y.EntertainmentType))
                .ForMember(x => x.StreetName, o => o.MapFrom(y => y.Address.StreetName))
                .ForMember(x => x.HouseNumber, o => o.MapFrom(y => y.Address.HouseNumber));

            CreateMap<EventModel, EventModelDTO>()
                .ForMember(x => x.EventTitle, o => o.MapFrom(y => y.Title))
                .ForMember(x => x.Value, o => o.MapFrom(y => y.EventPrice.Value))
                .ForMember(x => x.VAT, o => o.MapFrom(y => y.EventPrice.VAT))
                .ForMember(x => x.Tax, o => o.MapFrom(y => y.EventPrice.Tax))
                .ForMember(x => x.isAvailable, o => o.MapFrom(y => y.isAvailable))
                .ForMember(x => x.Description, o => o.MapFrom(y => y.Description));

            CreateMap<UpdateEntertainmentDTO, EntertainmentModel>()
                .ForMember(x => x.Title, o => o.MapFrom(y => y.EntertainmentTitle))
                .ForMember(x => x.Description, o => o.MapFrom(y => y.Description))
                .ForMember(x => x.EntertainmentType, o => o.MapFrom(y => y.Type))
                .ForMember(x => x.Address.StreetName, o => o.MapFrom(y => y.StreetName))
                .ForMember(x => x.Address.HouseNumber, o => o.MapFrom(y => y.HouseNumber));

            CreateMap<UpdateEventDTO, EventModel>()
                .ForMember(x => x.Title, o => o.MapFrom(y => y.EventTitle))
                .ForMember(x => x.Description, o => o.MapFrom(y => y.Description))
                .ForMember(x => x.EventPrice.Value, o => o.MapFrom(y => y.Value))
                .ForMember(x => x.EventPrice.VAT, o => o.MapFrom(y => y.VAT))
                .ForMember(x => x.EventPrice.Tax, o => o.MapFrom(y => y.Tax));

            CreateMap<AddEntertainmentModelDTO, EntertainmentModel>()
                .ForMember(x => x.Title, o => o.MapFrom(y => y.EntertainmentTitle))
                .ForMember(x => x.Description, o => o.MapFrom(y => y.Description))
                .ForMember(x => x.EntertainmentType, o => o.MapFrom(y => y.Type));

            CreateMap<AddEventModelDTO, EventModel>()
                .ForMember(x => x.Title, o => o.MapFrom(y => y.EventTitle))
                .ForMember(x => x.Description, o => o.MapFrom(y => y.Description))
                .ForMember(x => x.EventPrice.Value, o => o.MapFrom(y => y.Value))
                .ForMember(x => x.EventPrice.VAT, o => o.MapFrom(y => y.VAT))
                .ForMember(x => x.EventPrice.Tax, o => o.MapFrom(y => y.Tax));

            
                







        }
    }
}
