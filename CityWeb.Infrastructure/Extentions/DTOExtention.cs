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

        public static UserProfileModelDTO ToUserProfileModelDTO(this ApplicationUserModel userModel)
        {
            return new UserProfileModelDTO()
            {
                FirstName = userModel.Profile.FirstName,
                LastName = userModel.Profile.LastName,
                Avatar = userModel.Profile.Avatar,
                Birthday = userModel.Profile.Birthday,
                Gender = userModel.Profile.Gender,
                Password = userModel.Profile.Password,
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
                    ApartmentNumber = carSharingModel.Location.ApartmentNumber
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
                    ApartmentNumber = carSharingModelDTO.Location.ApartmentNumber,
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
                Color = rentCarDTO.Color
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
            carSharing.Location.ApartmentNumber = updateDTO.Location.ApartmentNumber;
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
                    Value = productModelDTO.Value,
                    VAT = productModelDTO.VAT,
                    Tax = productModelDTO.Tax,
                },
            };
        }

        public static void UpdateProductFromDTO(this ProductModel productModel, ProductModelDTO productModelDTO)
        {
            productModel.ProductImage = productModelDTO.ProductImage;
            //productModel.ProductType = productModelDTO.ProductType;
            productModel.ProductPrice.Value = productModelDTO.Value;
            productModel.ProductPrice.VAT = productModelDTO.VAT;
            productModel.ProductPrice.Tax = productModelDTO.Tax;
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
