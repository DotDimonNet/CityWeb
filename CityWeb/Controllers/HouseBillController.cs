using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HouseBillDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Taste.Web.Controllers
{
    [ApiController]
    [Route("api/housebill")]
    public class HouseBillController : Controller
    {
        private readonly IHouseBillService _houseBillService;

        public HouseBillController(IHouseBillService houseBillService)
        {
            _houseBillService = houseBillService;
        }

        [HttpPost("housebill-create")]
        public async Task<IActionResult> CreateHouseBillModel([FromBody] CreateHouseBillModelDTO request)
        {
            try
            {
                var houseBill = await _houseBillService.CreateHouseBill(request);
                return Json(houseBill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("housebill-update")]
        public IActionResult UpdateHouseBill([FromBody] UpdateHouseBillModelDTO request)
        {
            try
            {
                var houseBill = _houseBillService.UpdateHouseBill(request);
                return Json(houseBill.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-housebill")]
        public async Task<IActionResult> DeleteHousBill([FromBody] DeleteHouseBillModelDTO request)
        {
            try
            {
                var isDeleted = await _houseBillService.DeleteHouseBill(request);
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
                var houseBill = await _houseBillService.CreateCounter(request);
                return Json(houseBill);
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
                var houseBill = _houseBillService.UpdateCounter(request);
                return Json(houseBill.Result);
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
                var isDeleted = await _houseBillService.DeleteCounter(request);
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
                var counters = await _houseBillService.GetAllCounters();
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
                var houseBills = await _houseBillService.GetAllHouseBills();
                return Ok(houseBills);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
