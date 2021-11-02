using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Authorization;
using CityWeb.Infrastructure.Interfaces.Service;
using CityWeb.Domain.DTO.HotelDTO;

namespace CityWeb.Controllers
{
    [ApiController]
    [Route("api/Hotel")]
    [Authorize(Policy = Policies.RequireUserRole)]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HotelController> _logger;
        public HotelController(ILogger<HotelController> logger, IHotelService hotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
        }

        [HttpPost("hotel")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDTO request)
        {
            try
            {
                var hotel = await _hotelService.AddHotel(request);
                return Json(hotel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("hotel")]
        public async Task<IActionResult> RemoveHotel([FromBody] DeleteHotelDTO request)
        {
            try
            {
                var isRemoved = await _hotelService.RemoveHotel(request);
                return Ok(isRemoved);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("room")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDTO request)
        {
            try
            {
                var hotel = await _hotelService.AddRoom(request);
                return Json(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("room")]
        public async Task<IActionResult> RemoveRoom([FromBody] DeleteRoomDTO request)
        {
            try
            {
                var isRemoved = await _hotelService.RemoveRoom(request);
                return Ok(isRemoved);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            return  new JsonResult(1);
        }
    }
}
