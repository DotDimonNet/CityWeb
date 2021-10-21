using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
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
    public class ServiceExample 
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        public ServiceExample(ApplicationContext context, SignInManager<ApplicationUserModel> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUserModel> RegisterUser(RegisterModelDTO registerModel)
        {
            var user = new ApplicationUserModel() 
            {
                UserName = registerModel.UserName,
                Profile = new UserProfileModel() 
                {
                    Name = registerModel.Name
                }
            };
            var result = await _signInManager.UserManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                return  await _context.Users.FirstOrDefaultAsync(x => x.UserName == registerModel.UserName);
            }
            else
            {
                throw new Exception("User was not created!");
            }
        }
    }
}
