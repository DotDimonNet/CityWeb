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

        public static CarSharingModelDTO ToCarSharingModelDTO(this CarSharingModel carSharingModel)
        {
            return new CarSharingModelDTO()
            {
                Title = carSharingModel.Title,
                Description = carSharingModel.Description,
                Location = new AddressModelDTO()
                {
                     StreetName = carSharingModel.Location.StreetName,
                     HouseNumber = carSharingModel.Location.HouseNumber,
                     ApartmentNubmer = carSharingModel.Location.ApartmentNumber
                }
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

        public static CarSharingModel FromCreateCarSharingModelDTO(this CreateCarSharingModelDTO carSharingModelDTO)
        {
            return new CarSharingModel()
            {
                Title = carSharingModelDTO.Title,
                Description = carSharingModelDTO.Description,
                Location = new AddressModel()
                {
                    StreetName = carSharingModelDTO.Location.StreetName,
                    HouseNumber = carSharingModelDTO.Location.HouseNumber,
                    ApartmentNumber = carSharingModelDTO.Location.ApartmentNubmer,
                }
            };
        }

        public static RentCarModel FromAddRentCarModelDTO(this CarSharingModel carSharing, AddRentCarDTO rentCarDTO)
        {
            return new RentCarModel()
            {
                CarSharingId = carSharing.Id,
                Mark = rentCarDTO.Mark,
                Number = rentCarDTO.Number,
                Seats = rentCarDTO.Seats,
                VINCode = rentCarDTO.VINCode,
                Color = rentCarDTO.Color,
                //Type. = TransportType
            };
        }

        public static UpdateCarSharingModelDTO ToUpdateCarSharingModelDTO(this CarSharingModel carSharingModel)
        {
            return new UpdateCarSharingModelDTO()
            {
                Title = carSharingModel.Title,
                Description = carSharingModel.Description,
                Location = carSharingModel.Location.ToAddressModelDTO()
            };
        }

        public static void FromUpdateCarSharingModelDTO(this CarSharingModel carSharing, UpdateCarSharingModelDTO updateDTO)
        {
            carSharing.Description = updateDTO.Description;
            carSharing.Location.StreetName = updateDTO.Location.StreetName;
            carSharing.Location.HouseNumber = updateDTO.Location.HouseNumber;
            carSharing.Location.ApartmentNumber = updateDTO.Location.ApartmentNubmer;
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

        public static TransportTypeDTO ToTransportTypeDTO(this RentCarModel rentCar)
        {
            return new TransportTypeDTO()
            {
                Name = rentCar.Type.Name
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

        public static RentCarModel FromAddRentCarDTO(this AddRentCarDTO rentCarDTO)
        {
            return new RentCarModel()
            {
                Mark = rentCarDTO.Mark,
                Number = rentCarDTO.Number,
                Color = rentCarDTO.Color,
                Seats = rentCarDTO.Seats,
                Type = rentCarDTO.Type
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
        public static DeliveryDTO ToDeliveryDTO(this DeliveryModel deliveryModel)
        {
            return new DeliveryDTO()
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
                Description = model.Description
            };
        }

        public static SelectDeliveryModelDTO ToSelectDeliveryModelDTO(this DeliveryModel model)
        {
            return new SelectDeliveryModelDTO()
            {
                Title = model.Title
            };
        }

        public static AddressModelDTO ToAddressModelDTO(this AddressModel model)
        {
            return new AddressModelDTO()
            {
                StreetName = model.StreetName,
                HouseNumber = model.HouseNumber,
                ApartmentNubmer = model.ApartmentNumber
            };
        }

        public static PeriodModelDTO ToPeriodModelDTO(this PeriodModel model)
        {
            return new PeriodModelDTO()
            {
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };
        }
    }
}
