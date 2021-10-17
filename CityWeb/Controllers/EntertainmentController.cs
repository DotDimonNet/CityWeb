﻿using CityWeb.Common.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntertainentController : ControllerBase
    {

        private readonly ILogger<EntertainentController> _logger;

        public EntertainentController(ILogger<EntertainentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetJourneys()
        {
            var conn = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CityWeb;Integrated Security=SSPI;";
            var syncManager = new DbSyncManager(conn);
            var context = new DbContext(conn, syncManager);
            await context.InitializeContext();
            return new JsonResult(1);
        }
    }
}
