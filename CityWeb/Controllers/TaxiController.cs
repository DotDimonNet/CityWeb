using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Interfaces;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("createTaxi")]
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

        [HttpPost("updateTaxi")]
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

        [HttpPost("deleteTaxi")]
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

        [HttpPost("addTaxiCar")]
        public async Task<IActionResult> AddTaxiCar([FromBody] AddTaxiCarDTO request)
        {
            try
            {
                var taxiCar = await _taxiService.CreateTaxiCar(request);
                return Json(taxiCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updateTaxiCar")]
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

        [HttpPost("deleteTaxiCar")]
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

        [HttpPost("setupTaxiBuilderResult")]
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

        /*[HttpPost("stepOne")]
        public async Task<IActionResult> StepOne([FromBody] TaxiBuilderResult builder, ICollection<AddressModel> addresses)
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
        }*/

        /*[HttpPost("stepTwo")]
        public async Task<IActionResult> StepTwo([FromBody] TaxiBuilderResult builder, string title)
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
        }*/

        /*[HttpPost("stepThree")]
        public async Task<IActionResult> StepThree([FromBody] TaxiBuilderResult builder, TransportType taxiType)
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
        }*/

        [HttpPost("getAllTaxis")]
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

        [HttpPost("getAllTaxiCars")]
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