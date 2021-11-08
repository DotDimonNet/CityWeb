using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Authorization;
using CityWeb.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Taste.Web.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDTO request)
        {
            try
            {
                var user = await _accountService.LoginUser(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDTO request)
        {
            try
            {
                var user = await _accountService.RegisterUser(request);
                return Json(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-account")]
        public async Task<IActionResult> UpdateData([FromBody] UpdateUserDataDTO request)
        {
            try
            {
                var user = await _accountService.UpdateUserData(request);
                return Json(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserPasswordDTO request)
        {
            try
            {
                var user = await _accountService.UpdateUserPassword(request);
                return Json(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("change-email")]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailDTO request)
        {
            try
            {
                var user = await _accountService.ChangeEmail(request);
                return Json(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOut();
            return NoContent();
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _accountService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-by-user-name")]
        public async Task<IActionResult> GetByName([FromQuery] GetUserByUserNameDTO request)
        {
            try
            {
                var user = await _accountService.GetUserByUserName(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-by-id")]
        public async Task<IActionResult> GetById([FromQuery] GetUserByIdDTO request)
        {
            try
            {
                var user = await _accountService.GetUserById(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}