using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Authorization;
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
        private readonly ILogger<EntertainmentController> _logger;
        public EntertainmentController(ILogger<EntertainmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            return new JsonResult(1);
        }
    }
}
