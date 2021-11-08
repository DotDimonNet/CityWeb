using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityWeb.Domain.DTO.NewsDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

namespace CityWeb.Mapping
{
    public class MappingNewsProfile : Profile
    {
        public MappingNewsProfile()
        {
            CreateMap<AddNewsModelDTO, NewsModel>()
                .ForMember(x => x.Type, o => o.MapFrom((z) => Enum.Parse<NewsType>(z.Type)));

            CreateMap<NewsModel, NewsModelDTO>()
                 .ForMember(x => x.Type, o => o.MapFrom(z => z.Type.ToString()));

            CreateMap<UpdateNewsModelDTO, NewsModel>()
                .ForMember(x => x.Type, o => o.MapFrom((z) => Enum.Parse<NewsType>(z.Type)));

            CreateMap<AddNewsItemDTO, NewsItemModel>();

            CreateMap<NewsItemModel, NewsItemModelDTO>();

            CreateMap<UpdateNewsItemDTO, NewsItemModel>();
        }
    }
}
