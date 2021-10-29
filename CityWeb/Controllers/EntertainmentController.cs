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
    [Route("api/Entertainment")]
    [Authorize(Policy = Policies.RequireUserRole)]

    
    public class EntertainmentController : Controller
    {
        private readonly IEntertainmentService _entertainmentService;
        public EntertainmentController(IEntertainmentService entertainmentService)
        {
            _entertainmentService = entertainmentService;
        }

        [HttpGet("events")]
        public async Task<IEntertainmentService> GetEventsFromEntertainment([FromBody] GetEventsFromEntertainmentsDTO request)
        {
            try
            {
                var user = await _entertainmentService.GetEventTitlesFromEntertainment(request);
                return (IEntertainmentService)Ok(user);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }
        [HttpGet("event")]
        public async Task<IEntertainmentService> GetEventFromEvents([FromBody] GetEventFromEventsDTO request)
        {
            try
            {
                var user = await _entertainmentService.GetEventFromEventTitles(request);
                return (IEntertainmentService)Ok(user);
            }
            catch (Exception ex)
            {
                return (IEntertainmentService)BadRequest(ex.Message);
            }
        }


    }
}
