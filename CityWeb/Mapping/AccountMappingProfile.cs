using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Mapping
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<RegisterModelDTO, ApplicationUserModel>()
                .ForMember(x => x.UserName, o => o.MapFrom(z => z.UserName))
                .ForMember(x => x.Email, o => o.MapFrom(z => z.Email))
                .ForMember(x => x.Profile, o => o.Ignore());
        }
    }
}
