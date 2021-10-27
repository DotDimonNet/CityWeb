using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Authorization;

namespace CityWeb.Controllers
{
    [ApiController]
    [Route("api/Hotel")]
    [Authorize(Policy = Policies.RequireUserRole)]
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> _logger;
        public HotelController(ILogger<HotelController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            return  new JsonResult(1);
        }
    }
}
