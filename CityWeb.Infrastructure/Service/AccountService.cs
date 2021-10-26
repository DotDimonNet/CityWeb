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

        public async Task<LoginModelDTO> LoginUser(LoginModelDTO loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginModel.Login);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, loginModel.Attempts > 5);
                switch (result)
                {
                    case var value when result.Succeeded:
                        return user.ToLoginModelDTO();
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
                user.Profile.FirstName = updateData.FirstName;
                user.Profile.LastName = updateData.LastName;
                user.Profile.Gender = updateData.Gender;
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

        /*        public async Task<UpdatePasswordDTO> UpdatePasswordData(UpdatePasswordDTO updatePassword)
                {
                    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == updatePassword.UserName);
                    if (user != null)
                    {
                       if(updatePassword.OldPassword == user.PasswordHash )
                        {
                            if(updatePassword.NewPassword == updatePassword.ConfirmPassword)
                            {
                                user.PasswordHash = updatePassword.NewPassword;
                                _context.Update(user);
                                await _context.SaveChangesAsync();
                                return user.ToPasswordDTO();
                            }
                            else
                            {
                                throw new Exception("Passwords do not match");
                            }
                        }
                       else
                        {
                            throw new Exception("Wrong old password!");
                        }               
                    }
                    else
                    {
                        throw new Exception("User not exist!");
                    }
                }*/
        public async Task<UpdatePasswordDTO> UpdatePasswordData(UpdatePasswordDTO updatePassword, ApplicationUserModel user)
        {
            if (updatePassword.OldPassword == user.PasswordHash)
            {
                if (updatePassword.NewPassword == updatePassword.ConfirmPassword)
                {
                    user.PasswordHash = updatePassword.NewPassword;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    return user.ToPasswordDTO();
                }
                else
                {
                    throw new Exception("Passwords do not match");
                }
            }
            else
            {
                throw new Exception("Wrong old password!");
            }
        }
        public async Task<EmailDTO> ChangeEmail(ChangeEmailDTO changeEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == changeEmail.UserName);
            if (user != null)
            {
                user.Email = changeEmail.Email;
                _context.Update(user);
                await _context.SaveChangesAsync();
                return user.ToEmailDTO();
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }

        public async Task<UpdateUserPasswordDTO> UpdateUserPassword(UpdateUserPasswordDTO updatePassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == updatePassword.Login);
            if (user != null && updatePassword.Password == user.PasswordHash)
            {
                
                user.PasswordHash = updatePassword.NewPassword/*ToHash*/;
                if (user.PasswordHash == updatePassword.ConfirmNewPassword/*ToHash*/)
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                } 
                return user.ToUpdateUserPasswordDTO();
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }
    }
}
