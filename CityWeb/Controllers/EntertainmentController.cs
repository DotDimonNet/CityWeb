using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Infrastructure.Authorization;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityWeb.Controllers
{
    [ApiController]
    [Route("api/entertainment")]

    public class EntertainmentController : Controller
    {
        private readonly IEntertainmentService _entertainmentService;
        public EntertainmentController(IEntertainmentService entertainmentService)
        {
            _entertainmentService = entertainmentService;
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEventsFromEntertainment(GetEventsFromEntertainmentsDTO request)
        {
            try
            {
                var entertainment = await _entertainmentService.GetEventsFromEntertainment(request);
                return Ok(entertainment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("add")]
        public async Task<IActionResult> AddEntertainment([FromBody] AddEntertainmentModelDTO request)
        {
            try
            {
                var entertainment = await _entertainmentService.AddEntertainmentModel(request);
                return Json(entertainment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdadeEntertainment([FromBody] UpdateEntertainmentDTO request)
        {
            try
            {
                var entertainment = await _entertainmentService.UpdadeEntertainmentModel(request);
                return Json(entertainment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteEntertainment([FromBody] DeleteEntertainmentDTO request)
        {
            try
            {
                var entertainment = await _entertainmentService.DeleteEntertainmentModel(request);
                return Ok(entertainment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("events/event")]
        public async Task<IActionResult> GetEventFromEvents(GetEventFromEventsDTO request)
        {
            try
            {
                var eventModel = await _entertainmentService.GetEventFromEventTitles(request);
                return Ok(eventModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("events/add")]
        public async Task<IActionResult> AddEvent([FromBody] AddEventModelDTO request)
        {
            try
            {
                var eventModel = await _entertainmentService.AddEventModel(request);
                return Json(eventModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("events/update")]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventDTO request)
        {
            try
            {
                var eventModel = await _entertainmentService.UpdateEventModel(request);
                return Json(eventModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("events/delete")]
        public async Task<IActionResult> DeleteEvent([FromBody] DeleteEventDTO request)
        {
            try
            {
                var eventModel = await _entertainmentService.DeleteEventModel(request);
                return Ok(eventModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
