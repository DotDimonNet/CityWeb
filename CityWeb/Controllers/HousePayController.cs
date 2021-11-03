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
    [Route("api/housepay")]
    public class HousePayController : Controller
    {
        private readonly IHousePayService _housePayService;

        public HousePayController(IHousePayService housePayService)
        {
            _housePayService = housePayService;
        }

        [HttpPost("housepay-create")]
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

        [HttpPut("housepay-update")]
        public IActionResult UpdateHousePay([FromBody] UpdateHousePayModelDTO request)
        {
            try
            {
                var housePay = _housePayService.UpdateHousePay(request);
                return Json(housePay.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-housepay")]
        public async Task<IActionResult> DeleteHousePay([FromBody] DeleteHousePayModelDTO request)
        {
            try
            {
                var isDeleted = await _housePayService.DeleteHousePay(request);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("counter-create")]
        public async Task<IActionResult> CreateCounterModel([FromBody] CreateCounterModelDTO request)
        {
            try
            {
                var housePay = await _housePayService.CreateCounterModel(request);
                return Json(housePay);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("counter-update")]
        public IActionResult UpdateCounterModel([FromBody] UpdateCounterModelDTO request)
        {
            try
            {
                var housePay = _housePayService.UpdateCounterModel(request);
                return Json(housePay.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-counter")]
        public async Task<IActionResult> DeleteCounterModel([FromBody] DeleteCounterModelDTO request)
        {
            try
            {
                var isDeleted = await _housePayService.DeleteCounterModel(request);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-counters")]
        public async Task<IActionResult> GetAllCounters()
        {
            try
            {
                var counters = await _housePayService.GetAllCounters();
                return Ok(counters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-house-pays")]
        public async Task<IActionResult> GetAllHousePays()
        {
            try
            {
                var housePays = await _housePayService.GetAllHousePays();
                return Ok(housePays);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
