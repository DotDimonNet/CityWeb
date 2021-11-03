using AutoMapper;
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
    public class AccountService : IAccountService
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        private readonly IMapper _mapper;
        public AccountService(ApplicationContext context, SignInManager<ApplicationUserModel> signInManager, IMapper mapper)
        {
            _context = context;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<ApplicationUserModel> RegisterUser(RegisterModelDTO registerModel)
        {
            var user = _mapper.Map<RegisterModelDTO, ApplicationUserModel>(registerModel);
            user.Profile = _mapper.Map<UserProfileModelDTO, UserProfileModel>(registerModel.Profile);
            user.Profile.Address = _mapper.Map<AddressModelDTO, AddressModel>(registerModel.Address);
            var result = await _signInManager.UserManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await _context.Users.AddAsync(user);
                return  await _context.Users.FirstOrDefaultAsync(x => x.UserName == registerModel.UserName);
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

        public async Task<UserDTO> LoginUser(LoginModelDTO loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginModel.Login);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, loginModel.Attempts > 5);
                return result switch
                {
                    var value when result.Succeeded => _mapper.Map<ApplicationUserModel, UserDTO>(user),
                    var value when result.IsLockedOut => throw new Exception("Locked out"),
                    _ => throw new Exception("Unknown Error")
                };
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }

        public async Task<UserDTO> UpdateUserData(UpdateUserDataDTO updateData)
        {
            await _context.Users.LoadAsync();
            await _context.UserProfiles.LoadAsync();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == updateData.UserName);
            if (user != null)
            {
                try
                {
                    user.Profile = _mapper.Map<UserProfileModelDTO, UserProfileModel>(updateData.Profile, user.Profile);
                    user.Profile.Address = _mapper.Map<AddressModelDTO, AddressModel>(updateData.Address, user.Profile.Address);
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    var userDTO = _mapper.Map<ApplicationUserModel, UserDTO>(user);
                    userDTO.Profile = _mapper.Map<UserProfileModel, UserProfileModelDTO>(user.Profile);
                    userDTO.Address = _mapper.Map<AddressModel, AddressModelDTO>(user.Profile.Address);
                    return userDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }

        public async Task<UserDTO> ChangeEmail(ChangeEmailDTO changeEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == changeEmail.UserName);
            if (user != null)
            {
                user.Email = changeEmail.Email;
                _context.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<ApplicationUserModel, UserDTO>(user);
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }

        public async Task<bool> UpdateUserPassword(UpdateUserPasswordDTO updatePassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == updatePassword.UserName);
            if (user != null)
            {

                var result = await _signInManager.UserManager.ChangePasswordAsync(user, updatePassword.Password, updatePassword.NewPassword);

                return result.Succeeded;
            }
            else
            {
                throw new Exception("User not exists!");
            }
        }

        public async Task<ICollection<UserDTO>> GetAllUsers(int skip = 0, int take = 10)
        {
            return await _context.Users.Skip(skip).Take(take).Select(x => _mapper.Map<ApplicationUserModel, UserDTO>(x)).ToListAsync();
        }

        public async Task<UserDTO> GetUserByUserName(GetUserByUserNameDTO byUserName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == byUserName.UserName);
            return _mapper.Map<ApplicationUserModel, UserDTO>(user); 
        }


    }
}
