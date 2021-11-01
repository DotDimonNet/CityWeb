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
        public async Task<IEntertainmentService> GetEventsFromEntertainment(GetEventsFromEntertainmentsDTO request)
        {
            try
            {
                var entertainment = await _entertainmentService.GetEventsFromEntertainment(request);
                return (IEntertainmentService)Ok(entertainment);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IEntertainmentService> AddEntertainment([FromBody] AddEntertainmentModelDTO request)
        {
            try
            {
                var entertainment = await _entertainmentService.AddEntertainmentModel(request);
                return (IEntertainmentService)Ok(entertainment);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IEntertainmentService> UpdadeEntertainment([FromBody] UpdateEntertainmentDTO request)
        {
            try
            {
                var entertainment = await _entertainmentService.UpdadeEntertainmentModel(request);
                return (IEntertainmentService)Ok(entertainment);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<IEntertainmentService> DeleteEntertainment([FromBody] DeleteEntertainmentDTO request)
        {
            try
            {
                var entertainment = await _entertainmentService.DeleteEntertainmentModel(request);
                return (IEntertainmentService)Ok(entertainment);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }

        [HttpGet("events/event")]
        public async Task<IEntertainmentService> GetEventFromEvents(GetEventFromEventsDTO request)
        {
            try
            {
                var eventModel = await _entertainmentService.GetEventFromEventTitles(request);
                return (IEntertainmentService)Ok(eventModel);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }

        [HttpPost("events/add")]
        public async Task<IEntertainmentService> AddEvent([FromBody] AddEventModelDTO request)
        {
            try
            {
                var eventModel = await _entertainmentService.AddEventModel(request);
                return (IEntertainmentService)Ok(eventModel);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }

        [HttpPost("events/update")]
        public async Task<IEntertainmentService> UpdateEvent([FromBody] UpdateEventDTO request)
        {
            try
            {
                var eventModel = await _entertainmentService.UpdateEventModel(request);
                return (IEntertainmentService)Ok(eventModel);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }

        [HttpPost("events/delete")]
        public async Task<IEntertainmentService> DeleteEvent([FromBody] DeleteEventDTO request)
        {
            try
            {
                var eventModel = await _entertainmentService.DeleteEventModel(request);
                return (IEntertainmentService)Ok(eventModel);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }

    }
}
