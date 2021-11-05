using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
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
            //Address
            CreateMap<AddressModel, AddressModelDTO>();
            CreateMap<AddressModelDTO, AddressModel>();

            //Period
            CreateMap<PeriodModel, PeriodModelDTO>();
            CreateMap<PeriodModelDTO, PeriodModel>();

            //Price
            CreateMap<PriceModel, PriceModelDTO>();
            CreateMap<PriceModelDTO, PriceModel>();

            //Mapper for delivery company
            CreateMap<CreateDeliveryModelDTO, DeliveryModel>()
                .ForMember(x => x.Service, o => o.Ignore());

            CreateMap<DeliveryModel, DeliveryModelDTO>();

            CreateMap<DeliveryModel, SelectDeliveryModelDTO>();

            CreateMap<DeliveryModelDTO, DeliveryModel>()
                .ForMember(x => x.Service, o => o.Ignore());

            CreateMap<UpdateDeliveryModelDTO, DeliveryModel>();


            //Mapper for product
            CreateMap<ProductModelDTO, ProductModel>();

            CreateMap<ProductModel, ProductModelDTO>()
                .ForMember(x => x.ProductType, o => o.MapFrom(z => z.ProductType.ToString()));

            CreateMap<CreateProductModelDTO, ProductModel>()
                .ForMember(x => x.ProductType, o => o.MapFrom((z) => Enum.Parse<ProductType>(z.ProductType)));

            CreateMap<UpdateProductModelDTO, ProductModel>()
                .ForMember(x => x.ProductType, o => o.MapFrom((z) => Enum.Parse<ProductType>(z.ProductType)));
            
            CreateMap<ProductModel, ProductUpdateDTO>();
                
            CreateMap<ProductModel, SelectDeliveryModelDTO>();
        }
    }
}
