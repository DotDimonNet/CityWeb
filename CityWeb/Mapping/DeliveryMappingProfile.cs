using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Mapping
{
    public class DeliveryMappingProfile : Profile
    {
        public DeliveryMappingProfile()
        {
            //Mapper for delivery company
            CreateMap<CreateDeliveryModelDTO, DeliveryModel>()
                .ForMember(x => x.DeliveryAdress, o => o.Ignore())
                .ForMember(x => x.DeliveryPrice, o => o.Ignore())
                .ForMember(x => x.Service, o => o.Ignore())
                .ForMember(x => x.WorkSchedule, o => o.Ignore());

            CreateMap<DeliveryModel, CreateDeliveryModelDTO>();//??

            CreateMap<DeliveryModel, SelectDeliveryModelDTO>();

            CreateMap<DeliveryModelDTO, DeliveryModel>()
                .ForMember(x => x.Service, o => o.Ignore());

            CreateMap<DeliveryModel, DeliveryModelDTO>()
                .ForMember(x => x.Description, o => o.MapFrom(z => z.Description))
                .ForMember(x => x.Title, o => o.MapFrom(z => z.Title));

            CreateMap<UpdateDeliveryModelDTO, DeliveryModel>()
                .ForMember(x => x.WorkSchedule, o => o.Ignore())
                .ForMember(x => x.DeliveryPrice, o => o.Ignore());

            //Mapper for product
            CreateMap<ProductModelDTO, ProductModel>()
                .ForMember(x => x.ProductType, o => o.Ignore());

            CreateMap<ProductModel, CreateProductDTO>()
                .ForMember(x => x.ProductType, o => o.Ignore())
                .ForMember(x => x.Price, o => o.Ignore());


            CreateMap<ProductModel, ProductUpdateDTO>();
                
            CreateMap<ProductModel, SelectDeliveryModelDTO>();
           
        }
    }
}
