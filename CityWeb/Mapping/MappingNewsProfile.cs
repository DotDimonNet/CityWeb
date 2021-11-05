using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityWeb.Domain.DTO.NewsDTO;
using CityWeb.Domain.Entities;

namespace CityWeb.Mapping
{
    public class MappingNewsProfile : Profile
    {
        public MappingNewsProfile()
        {
            CreateMap<AddNewsModelDTO, NewsModel>()
                .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<NewsModel, NewsModelDTO>()
                 .ForMember(x => x.Type, o => o.Ignore());
            CreateMap<UpdateNewsModelDTO, NewsModel>()
                .ForMember(x => x.Type, o => o.Ignore())
                .ForMember(x => x.Title, o => o.Ignore());
            CreateMap<AddNewsItemDTO, NewsItemModel>();


        }
    }
}
