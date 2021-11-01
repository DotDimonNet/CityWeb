using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.DeliveryDTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Extentions
{
    public static class DTOExtention
    {
        public static UserDTO ToUserDTO(this ApplicationUserModel userModel)
        {
            return new UserDTO()
            {
                StreetName = userModel.Profile.Address.StreetName,
                HouseNumber = userModel.Profile.Address.HouseNumber,
                ApartmentNumber = userModel.Profile.Address.ApartmentNumber,
                Avatar = userModel.Profile.Avatar,
            };
        }

        public static UpdatePasswordDTO ToPasswordDTO(this ApplicationUserModel userModel)
        {
            return new UpdatePasswordDTO()
            {
                UserName = userModel.UserName,
                OldPassword = userModel.PasswordHash
            };
        }

        public static LoginModelDTO ToLoginModelDTO(this ApplicationUserModel userModel)
        {
            return new LoginModelDTO()
            {
                Login = userModel.UserName,
                Password = userModel.PasswordHash,
                Attempts = 0
            };
        }

        public static EmailDTO ToEmailDTO(this ApplicationUserModel userModel)
        {
            return new EmailDTO()
            {
                Email = userModel.Email,
            };
        }

        public static TaxiModelDTO ToTaxiModelDTO(this TaxiModel taxiModel)
        {
            return new TaxiModelDTO()
            {
                Title = taxiModel.Title,
                Description = taxiModel.Description
            };
        }

        public static CreateTaxiModelDTO ToCreateTaxiModelDTO(this TaxiModel taxiModel)
        {
            return new CreateTaxiModelDTO()
            {
                Title = taxiModel.Title,
                Description = taxiModel.Description
            };
        }

        public static UpdateTaxiModelDTO ToUpdateTaxiModelDTO(this TaxiModel taxiModel)
        {
            return new UpdateTaxiModelDTO()
            {
                Title = taxiModel.Title,
                Description = taxiModel.Description
            };
        }

        public static CreateCarSharingModelDTO ToCreateCarSharingModelDTO(this CarSharingModel carSharingModel)
        {
            return new CreateCarSharingModelDTO()
            {
                Title = carSharingModel.Title,
                Description = carSharingModel.Description
            };
        }

        public static UpdateCarSharingModelDTO ToUpdateCarSharingModelDTO(this CarSharingModel carSharingModel)
        {
            return new UpdateCarSharingModelDTO()
            {
                Title = carSharingModel.Title,
                Description = carSharingModel.Description,
                Location = carSharingModel.Location
            };
        }

        public static UpdateTaxiCarDTO ToUpdateTaxiCarDTO(this TaxiCarModel taxiCar)
        {
            return new UpdateTaxiCarDTO()
            {
                VINCode = taxiCar.VINCode,
                Type = taxiCar.Type,
                Mark = taxiCar.Mark,
                Color = taxiCar.Color,
                Number = taxiCar.Number,
                Seats = taxiCar.Seats
            };
        }

        public static AddRentCarDTO ToAddRentCarDTO(this RentCarModel rentCar)
        {
            return new AddRentCarDTO()
            {
                VINCode = rentCar.VINCode,
                Type = rentCar.Type,
                Mark = rentCar.Mark,
                Color = rentCar.Color,
                Number = rentCar.Number,
                Seats = rentCar.Seats
            };
        }

        public static UpdateRentCarDTO ToUpdateRentCarDTO(this RentCarModel rentCar)
        {
            return new UpdateRentCarDTO()
            {
                VINCode = rentCar.VINCode,
                Type = rentCar.Type,
                Mark = rentCar.Mark,
                Color = rentCar.Color,
                Number = rentCar.Number,
                Seats = rentCar.Seats
            };
        }

        public static RentCarsModelDTO ToRentCarsModelDTO(this RentCarModel rentCar)
        {
            return new RentCarsModelDTO()
            {
                VINCode = rentCar.VINCode,
                Type = rentCar.Type,
                Mark = rentCar.Mark,
                Color = rentCar.Color,
                Number = rentCar.Number,
                Seats = rentCar.Seats
            };
        }

        public static UpdateUserPasswordDTO ToUpdateUserPasswordDTO(this ApplicationUserModel userModel)
        {
            return new UpdateUserPasswordDTO()
            {
                UserName = userModel.UserName,
                Password = userModel.PasswordHash
            };
        }
        //for delivery
        public static UpdatedDeliveryDTO ToUpdatedDeliveryDTO(this DeliveryModel deliveryModel)
        {
            return new UpdatedDeliveryDTO()
            {
                Title = deliveryModel.Title,
                DeliveryImage = deliveryModel.DeliveryImage,
                Description = deliveryModel.Description,
                StartTime = deliveryModel.WorkSchedule.StartTime,
                EndTime = deliveryModel.WorkSchedule.EndTime,
                Value = deliveryModel.DeliveryPrice.Value,
                Tax = deliveryModel.DeliveryPrice.Tax,
                VAT = deliveryModel.DeliveryPrice.VAT,
            };
        }

        public static ProductUpdateDTO ToProductUpdateDTO(this ProductModel productModel)
        {
            return new ProductUpdateDTO()
            {
                ProductName = productModel.ProductName,
                ProductImage = productModel.ProductImage,
                Value = productModel.ProductPrice.Value,
                Tax = productModel.ProductPrice.Tax,
                VAT = productModel.ProductPrice.VAT,
            };
        }

        public static CreateProductDTO ToCreateProductDTO(this ProductModel productModel)
        {
            return new CreateProductDTO()
            {
                ProductName = productModel.ProductName,
                ProductImage = productModel.ProductImage,
                ProductType = productModel.ProductType,
                Value = productModel.ProductPrice.Value,
                Tax = productModel.ProductPrice.Tax,
                VAT = productModel.ProductPrice.VAT,
            };
        }

        public static ProductModelDTO ToProductDTO(this ProductModel productModel)
        {
            return new ProductModelDTO()
            {
                ProductName = productModel.ProductName,
                ProductImage = productModel.ProductImage,
                Value = productModel.ProductPrice.Value,
                Tax = productModel.ProductPrice.Tax,
                VAT = productModel.ProductPrice.VAT,
            };
        }

        public static DeliveryModelDTO ToDeliveryModelDTO(this DeliveryModel model)
        {
            return new DeliveryModelDTO()
            {
                Title = model.Title,
                DeliveryId = model.Id,
                Description = model.Description,
                DeliveryImage = model.DeliveryImage,
                StartTime = model.WorkSchedule.StartTime,
                EndTime = model.WorkSchedule.EndTime,
                Value = model.DeliveryPrice.Value,
                Tax = model.DeliveryPrice.Tax,
                VAT = model.DeliveryPrice.VAT,
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
        public static CreatedDeliveryModelDTO ToCreatedDeliveryModelDTO(this DeliveryModel deliveryModel)
        {
            return new CreatedDeliveryModelDTO()
            {
                Title = deliveryModel.Title,
                Description = deliveryModel.Description,
            };
        }
        public static void UpdateFromDTO(this DeliveryModel delivery, UpdateDeliveryModelDTO deliveryModel)
        {
            delivery.Description = deliveryModel.Description;
            delivery.WorkSchedule.StartTime = deliveryModel.StartTime;
            delivery.WorkSchedule.EndTime = deliveryModel.EndTime;
            delivery.DeliveryPrice.Value = deliveryModel.Value;
            delivery.DeliveryPrice.Tax = deliveryModel.Tax;
            delivery.DeliveryPrice.VAT = deliveryModel.VAT;
        }

        public static ProductModel CreateProductFromDTO(this DeliveryModel deliveryModel, ProductModelDTO productModelDTO)
        {
            return new ProductModel()
            {
                DeliveryId = deliveryModel.Id,
                ProductImage = productModelDTO.ProductImage,
                ProductName = productModelDTO.ProductName,
                ProductType = productModelDTO.ProductType,
                ProductPrice = new PriceModel()
                {
                    Value = productModelDTO.Value,
                    VAT = productModelDTO.VAT,
                    Tax = productModelDTO.Tax,
                },
            };
        }

        public static void UpdateProductFromDTO(this ProductModel productModel, ProductModelDTO productModelDTO)
        {
            productModel.ProductImage = productModelDTO.ProductImage;
            productModel.ProductType = productModelDTO.ProductType;
            productModel.ProductPrice.Value = productModelDTO.Value;
            productModel.ProductPrice.VAT = productModelDTO.VAT;
            productModel.ProductPrice.Tax = productModelDTO.Tax;
        }
    }
}
