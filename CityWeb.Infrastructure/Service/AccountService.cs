using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Infrastructure.Interfaces;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Service
{
    public class AccountService 
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        public AccountService(ApplicationContext context, SignInManager<ApplicationUserModel> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUserModel> RegisterUser(RegisterModelDTO registerModel)
        {
            var user = new ApplicationUserModel() 
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,                
                Profile = new UserProfileModel() 
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Birthday = registerModel.Birthday,
                    Gender = registerModel.Gender,
                }
            };
            var result = await _signInManager.UserManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                return  await _context.Users.FirstOrDefaultAsync(x => x.UserName == registerModel.Email);
            }
            else
            {
                throw new Exception("User was not created!");
            }
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUserModel> LoginUser(LoginModelDTO loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginModel.Login);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, loginModel.Attempts > 5);
                switch (result)
                {
                    case var value when result.Succeeded:
                        return user;
                    case var value when result.IsLockedOut:
                        throw new Exception("Locked out");
                    default:
                        throw new Exception("Unknown Error");
                }
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }

        public async Task<UserDTO> UpdateUserData(UpdateUserDataDTO updateData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == updateData.Login);
            if (user != null)
            {
                user.Profile.Address = new AddressModel()
                {
                    StreetName = updateData.StreetName,
                    HouseNumber = updateData.HouseNumber,
                    ApartmentNumber = updateData.ApartmentNumber,
                };
                user.Profile.Avatar = updateData.Avatar;

                _context.Update(user);
                await _context.SaveChangesAsync();
                return user.ToUserDTO();
            }
            else
            {
                throw new Exception("User not exist!");
            }

        }
    }
}
