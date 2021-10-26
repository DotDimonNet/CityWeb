using CityWeb.Domain.DTO;

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
        //for delivery
        public static DeliveryDTO ToDeliveryDTO(this DeliveryModel deliveryModel)
        {
            return new DeliveryDTO()
            {
                DeliveryImage = deliveryModel.DeliveryImage,
                Description = deliveryModel.Description,
                StartTime = deliveryModel.WorkSchedule.StartTime,
                EndTime = deliveryModel.WorkSchedule.EndTime,
                Value = deliveryModel.DeliveryPrice.Value,
                Tax = deliveryModel.DeliveryPrice.Tax,
                VAT = deliveryModel.DeliveryPrice.VAT,
            };
        }

        public static ProductUpdateDTO ToProductPriceDTO(this ProductModel productModel)
        {
            return new ProductUpdateDTO()
            {
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
                Value = productModel.ProductPrice.Value,
                Tax = productModel.ProductPrice.Tax,
                VAT = productModel.ProductPrice.VAT,
            };
        }

        


    }
}
