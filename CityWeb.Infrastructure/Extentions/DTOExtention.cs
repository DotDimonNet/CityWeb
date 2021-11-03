using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Extentions
{
    public static class DTOExtention
    {
        //for delivery

        public static ProductUpdateDTO ToProductUpdateDTO(this ProductModel productModel)
        {
            return new ProductUpdateDTO()
            {
                ProductName = productModel.ProductName,
                ProductImage = productModel.ProductImage,
                //Value = productModel.ProductPrice.Value,
                //Tax = productModel.ProductPrice.Tax,
                //VAT = productModel.ProductPrice.VAT,
            };
        }

        public static ProductModelDTO ToProductDTO(this ProductModel productModel)
        {
            return new ProductModelDTO()
            {
                ProductName = productModel.ProductName,
                ProductImage = productModel.ProductImage,
                //Value = productModel.ProductPrice.Value,
                //Tax = productModel.ProductPrice.Tax,
                //VAT = productModel.ProductPrice.VAT,
            };
        }

        public static DeliveryModelDTO ToDeliveryModelDTO(this DeliveryModel model)
        {
            return new DeliveryModelDTO()
            {
                Title = model.Title,
                //DeliveryId = model.Id,
                Description = model.Description,
                DeliveryImage = model.DeliveryImage,
                WorkShedyle = new PeriodModelDTO()
                {
                    StartTime = model.WorkSchedule.StartTime,
                    EndTime = model.WorkSchedule.EndTime,
                },
                DeliveryPrice = new PriceModelDTO()
                {
                    Value = model.DeliveryPrice.Value,
                    Tax = model.DeliveryPrice.Tax,
                    VAT = model.DeliveryPrice.VAT,
                }
            };
        }

        public static SelectDeliveryModelDTO ToSelectDeliveryModelDTO(this DeliveryModel model)
        {
            return new SelectDeliveryModelDTO()
            {
                Title = model.Title
            };
        }
        public static DeliveryModel CreateFromDTO(this CreateDeliveryModelDTO deliveryModel)
        {
            return new DeliveryModel()
            {
                Title = deliveryModel.Title,
                Description = deliveryModel.Description,
                Service = new ServiceModel(),
                DeliveryAdress = new AddressModel(),
                WorkSchedule = new PeriodModel(),
                DeliveryPrice = new PriceModel()
            };
        }
        public static CounterModel FromCreateCounterModelDTO(this CreateCounterModelDTO counterModelDTO)
        {
            return new CounterModel()
            {
                Number = counterModelDTO.Number,
                StartCount = counterModelDTO.StartCount,
                Type = counterModelDTO.Type
            };
        }
        public static UpdateCounterModelDTO ToUpdateCounterModelDTO(this CounterModel counterModel)
        {
            return new UpdateCounterModelDTO()
            {
                StartCount = counterModel.StartCount,
                EndCount = counterModel.EndCount,
                PriceByItem = counterModel.PriceByItem
            };
        }

        public static ProductModel CreateProductFromDTO(this DeliveryModel deliveryModel, ProductModelDTO productModelDTO)
        {
            return new ProductModel()
            {
                DeliveryId = deliveryModel.Id,
                ProductImage = productModelDTO.ProductImage,
                ProductName = productModelDTO.ProductName,
                //ProductType = productModelDTO.ProductType,
                ProductPrice = new PriceModel()
                {
                   // Value = productModelDTO.Value,
                    //VAT = productModelDTO.VAT,
                    //Tax = productModelDTO.Tax,
                },
            };
        }

        public static void UpdateProductFromDTO(this ProductModel productModel, ProductModelDTO productModelDTO)
        {
            productModel.ProductImage = productModelDTO.ProductImage;
            //productModel.ProductType = productModelDTO.ProductType;
            //productModel.ProductPrice.Value = productModelDTO.Value;
            //productModel.ProductPrice.VAT = productModelDTO.VAT;
            //productModel.ProductPrice.Tax = productModelDTO.Tax;
        }

        public static HousePayModelDTO ToHousePayModelDTO(this HousePayModel model)
        {
            return new HousePayModelDTO()
            {
                Title = model.Title,
                Description = model.Description,
                Counter = new CounterModel()
            };
        }
        public static HousePayModel CreateFromDTO(this HousePayModel housePayModel, CreateHousePayModelDTO housePayModelDTO)
        {
            return new HousePayModel()
            {
                Title = housePayModelDTO.Title,
                Description = housePayModelDTO.Description,
                Service = new ServiceModel(),
                HouseHoldAdress = new AddressModel(),
            };
        }
        public static CreateHousePayModelDTO ToCreatedHousePayModelDTO(this HousePayModel housePayModel)
        {
            return new CreateHousePayModelDTO()
            {
                Title = housePayModel.Title,
                Description = housePayModel.Description,
            };
        }

        public static SelectHousePayModelDTO ToSelectHousePayModelDTO(this HousePayModel model)
        {
            return new SelectHousePayModelDTO()
            {
                Title = model.Title
            };
        }
        public static void UpdateFromlDTO(this HousePayModel housePayModel, HousePayModelDTO housePayModelDTO )
        {
            housePayModel.Title = housePayModelDTO.Title;
            housePayModel.Description = housePayModelDTO.Description;
        }
        public static CounterModel CreateCounterFromlDTO(this CreateCounterModelDTO counterModelDTO)
        {
            return new CounterModel()
            {
                Number = counterModelDTO.Number,
                StartCount = counterModelDTO.StartCount,
                Type = counterModelDTO.Type
            };
        }
        public static SelectCounterModelDTO ToSelectCounterModelDTO(this CounterModel model)
        {
            return new SelectCounterModelDTO()
            {
                Number = model.Number
            };
        }

        public static CounterModel CreateFromDTO(this CreateCounterModelDTO counterModel)
        {
            return new CounterModel()
            {
                Number = counterModel.Number,
                StartCount = counterModel.StartCount,
                Type = counterModel.Type
            };
        }
        public static CounterModelDTO ToCounterModelDTO(this CounterModel counterModel)
        {
            return new CounterModelDTO()
            {
                Number = counterModel.Number,
                StartCount = counterModel.StartCount,
                EndCount = counterModel.EndCount,
            };
        }
        public static AddressModelDTO ToAddressModelDTO(this AddressModel model)
        {
            return new AddressModelDTO()
            {
                StreetName = model.StreetName,
                HouseNumber = model.HouseNumber,
                ApartmentNumber = model.ApartmentNumber
            };
        }
    }
}
