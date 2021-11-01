using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taste.Web.Controllers
{
    [ApiController]
    [Route("api/Taxi")]
    public class TaxiController : Controller
    {
        private readonly ITaxiService _taxiService;

        public TaxiController(ITaxiService taxiService)
        {
            _taxiService = taxiService;
        }

        [HttpPost("taxi")]
        public async Task<IActionResult> CreateTaxi([FromBody] CreateTaxiModelDTO request)
        {
            try
            {
                var taxi = await _taxiService.CreateTaxi(request);
                return Json(taxi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("taxi")]
        public async Task<IActionResult> UpdateTaxi([FromBody] UpdateTaxiModelDTO request)
        {
            try
            {
                var taxi = await _taxiService.UpdateTaxi(request);
                return Json(taxi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("taxi")]
        public async Task<IActionResult> DeleteTaxi([FromBody] DeleteTaxiModelDTO request)
        {
            try
            {
                var isDeleted = await _taxiService.DeleteTaxi(request);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("taxi-car")]
        public async Task<IActionResult> AddTaxiCar([FromBody] AddTaxiCarDTO request)
        {
            try
            {
                var taxiCar = await _taxiService.AddTaxiCar(request);
                return Json(taxiCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("taxi-car")]
        public async Task<IActionResult> UpdateTaxiCar([FromBody] UpdateTaxiCarDTO request)
        {
            try
            {
                var taxiCar = await _taxiService.UpdateTaxiCar(request);
                return Json(taxiCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("taxi-car")]
        public async Task<IActionResult> DeleteTaxiCar([FromBody] DeleteTaxiCarDTO request)
        {
            try
            {
                var isDeleted = await _taxiService.DeleteTaxiCar(request);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("setup-taxi-builder-result")]
        public IActionResult SetupTaxiBuilderResult()
        {
            try
            {
                var builderResult = _taxiService.SetupTaxiBuilderResult();
                return Json(builderResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("step-one")]
        public async Task<IActionResult> StepOne([FromBody] TaxiBuilderResult builder, [FromQuery] ICollection<AddressModel> addresses)
        {
            try
            {
                var stepOneResult = await _taxiService.StepOne(builder, addresses);
                return Json(stepOneResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("step-two")]
        public async Task<IActionResult> StepTwo([FromBody] TaxiBuilderResult builder, [FromQuery] string title)
        {
            try
            {
                var stepTwoResult = await _taxiService.StepTwo(builder, title);
                return Json(stepTwoResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("step-three")]
        public async Task<IActionResult> StepThree([FromBody] TaxiBuilderResult builder, [FromQuery] TransportType taxiType)
        {
            try
            {
                var stepThreeResult = await _taxiService.StepThree(builder, taxiType);
                return Ok(stepThreeResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-taxis")]
        public IActionResult GetAllTaxis()
        {
            try
            {
                var Taxis = _taxiService.GetAllTaxis();
                return Json(Taxis);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-taxi-cars")]
        public IActionResult GetAllTaxiCars()
        {
            try
            {
                var taxiCars = _taxiService.GetAllTaxiCars();
                return Json(taxiCars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}