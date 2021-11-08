using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Infrastructure.Interfaces;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccountService> _logger;
        public AccountService(ApplicationContext context, SignInManager<ApplicationUserModel> signInManager, IMapper mapper, ILogger<AccountService> logger)
        {
            _context = context;
            _signInManager = signInManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> RegisterUser(RegisterModelDTO registerModel)
        {
            var user = _mapper.Map<RegisterModelDTO, ApplicationUserModel>(registerModel);
            var result = await _signInManager.UserManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                try
                {
                    await _context.Users.AddAsync(user);

                    _logger.LogInformation("User was created");

                    var userDTO = await _context.Users.FirstOrDefaultAsync(x => x.UserName == registerModel.UserName);
                    return _mapper.Map<ApplicationUserModel, UserDTO>(userDTO);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
                _logger.LogError("User was not created!");
                throw new Exception("User was not created!");
        }   

        public async Task SignOut()
        {
            try
            {
                await _signInManager.SignOutAsync();

                _logger.LogInformation("User signout");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDTO> LoginUser(LoginModelDTO loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginModel.Login);

            if (user != null)
            {
                try
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, loginModel.Attempts > 5);
                   
                    _logger.LogInformation($"User {loginModel.Login} try to login with status: {result.Succeeded}");
                    
                    return result switch
                    {
                        var value when result.Succeeded => _mapper.Map<ApplicationUserModel, UserDTO>(user),
                        var value when result.IsLockedOut => throw new Exception("Locked out"),
                        _ => throw new Exception("Unknown Error")
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
                _logger.LogError($"User {loginModel.Login} not exist!");
                throw new Exception("User not exist!");
        }

        public async Task<UserDTO> UpdateUserData(UpdateUserDataDTO updateData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updateData.UserId);
            if (user != null)
            {
                try
                {
                    user.Profile = _mapper.Map<UserProfileModelDTO, UserProfileModel>(updateData.Profile, user.Profile);
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"User {updateData.UserId} was updated");

                    return _mapper.Map<ApplicationUserModel, UserDTO>(user);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            _logger.LogError($"User {updateData.UserId} not exist!");
            throw new Exception("User not exist!");
        }

        public async Task<UserDTO> ChangeEmail(ChangeEmailDTO changeEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == changeEmail.UserId);
            if (user != null)
            {
                try
                {
                    user.Email = changeEmail.Email;
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"User {changeEmail.UserId} changed email");

                    return _mapper.Map<ApplicationUserModel, UserDTO>(user);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            _logger.LogError($"User {changeEmail.UserId} not exist!");
            throw new Exception("User not exist!");
        }

        public async Task<bool> UpdateUserPassword(UpdateUserPasswordDTO updatePassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updatePassword.UserId);
            if (user != null)
            {
                try
                {
                    var result = await _signInManager.UserManager.ChangePasswordAsync(user, updatePassword.Password, updatePassword.NewPassword);

                    _logger.LogInformation($"User {updatePassword.UserId} changed password");

                    return result.Succeeded;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            _logger.LogError($"User {updatePassword.UserId} not exist!");
            throw new Exception("User not exist!");   
        }

        public async Task<ICollection<UserDTO>> GetAllUsers(int skip = 0, int take = 10)
        {
            try
            {
                return await _context.Users.Skip(skip).Take(take).Select(x => _mapper.Map<ApplicationUserModel, UserDTO>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDTO> GetUserById(GetUserByIdDTO getById)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == getById.UserId);
                return _mapper.Map<ApplicationUserModel, UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDTO> GetUserByUserName(GetUserByUserNameDTO byUserName)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == byUserName.UserName);
                return _mapper.Map<ApplicationUserModel, UserDTO>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
