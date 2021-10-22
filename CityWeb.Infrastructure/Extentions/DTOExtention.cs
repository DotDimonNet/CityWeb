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
        
        public static UpdateUserPasswordDTO ToUpdateUserPasswordDTO(this ApplicationUserModel userModel)
        {
            return new UpdateUserPasswordDTO()
            {
                Login = userModel.Email,
                Password = userModel.PasswordHash  
            };
        }

        public static AddEntertainmentDTO ToAddEntertainment(this EntertainmentModel entertainmentModel)
        {
            return new AddEntertainmentDTO()
            {
                Title = entertainmentModel.Title,
                Description = entertainmentModel.Description,
                Price = entertainmentModel.Price,
                Type = entertainmentModel.EventType,

            };
        }


        
    }
}
