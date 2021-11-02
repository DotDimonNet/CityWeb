using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HousePayDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Taste.Web.Controllers
{
    [ApiController]
    [Route("api/house-pay")]
    public class HousePayController : Controller
    {
        private readonly IHousePayService _housePayService;

        public HousePayController(IHousePayService housePayService)
        {
            _housePayService = housePayService;
        }

        [HttpPost("manage-house-pay")]
        public async Task<IActionResult> CreateHousePayModel([FromBody] CreateHousePayModelDTO request)
        {
            try
            {
                var housePay = await _housePayService.CreateHousePayModel(request);
                return Json(housePay);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}