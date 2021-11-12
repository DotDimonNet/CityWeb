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
using CityWeb.Domain.Entities;

namespace CityWeb.Controllers
{
    [ApiController]
    [Route("api/hotel")]
    //[Authorize(Policy = Policies.RequireUserRole)]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HotelController> _logger;
        public HotelController(ILogger<HotelController> logger, IHotelService hotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
        }

        [HttpPost("manage-hotel")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDTO request)
        {
            try
            {             
                return Json(await _hotelService.AddHotel(request));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("manage-hotel")]
        public async Task<IActionResult> UpdateHotel([FromBody] UpdateHotelDTO request)
        {
            try
            {
                return Json(await _hotelService.UpdateHotel(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("manage-hotel")]
        public async Task<IActionResult> RemoveHotel([FromBody] HotelIdDTO request)
        {
            try
            {               
                return Ok(await _hotelService.RemoveHotel(request));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("manage-room")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDTO request)
        {
            try
            {
                return Json(await _hotelService.AddRoom(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("manage-room")]
        public async Task<IActionResult> UpdateRoom([FromBody] UpdateRoomDTO request)
        {
            try
            {
                return Json(await _hotelService.UpdateRoom(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("manage-room")]
        public async Task<IActionResult> RemoveRoom([FromBody] DeleteRoomDTO request)
        {
            try
            {
                return Ok(await _hotelService.RemoveRoom(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("free-rooms")]
        public async Task<IActionResult> GetFreeRoomsInHotel([FromBody] HotelTitleDTO request)
        {
            try
            {
                return Json(await _hotelService.GetAllFreeRooms(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all-room-types")]
        public async Task<IActionResult> GetAllRoomTypesByHotelTitle([FromBody] HotelTitleDTO request)
        {
            try
            {
                return Json(await _hotelService.GetAllRoomTypesByHotelTitle(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("hotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                return Json(await _hotelService.GetAllHotels());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
