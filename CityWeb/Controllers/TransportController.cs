using CityWeb.Common.Repository;
using CityWeb.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Controllers
{
    [ApiController]
    [Route("api/transport")]
    [Authorize(Policy = Policies.RequireUserRole)]
    public class TransportController : Controller
    {
        private readonly ILogger<TransportController> _logger;

        public TransportController(ILogger<TransportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetJourneys()
        {
            return new JsonResult(1);
        }
    }
}
