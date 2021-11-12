using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Taste.Web.Controllers
{
    [ApiController]
    [Route("api/car-sharing")]
    public class CarSharingController : Controller
    {
        private readonly ICarSharingService _carSharingService;

        public CarSharingController(ICarSharingService carSharingService)
        {
            _carSharingService = carSharingService;
        }
        
        [HttpPost("manage-car-sharing")]
        public async Task<IActionResult> CreateCarSharing([FromBody] CreateCarSharingModelDTO request)
        {
            try
            {
                var carSharing = await _carSharingService.CreateCarSharing(request);
                return Json(carSharing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("manage-car-sharing")]
        public async Task<IActionResult> UpdateCarSharing([FromBody] UpdateCarSharingModelDTO request)
        {
            try
            {
                var carSharing = await _carSharingService.UpdateCarSharing(request);
                return Json(carSharing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("manage-car-sharing")]
        public async Task<IActionResult> DeleteCarSharing([FromQuery] DeleteCarSharingModelDTO request)
        {
            try
            {
                var isDeleted = await _carSharingService.DeleteCarSharing(request);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("rent-car")]
        public async Task<IActionResult> AddRentCar([FromBody] AddRentCarDTO request)
        {
            try
            {
                var rentCar = await _carSharingService.AddRentCar(request);
                return Json(rentCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("rent-car")]
        public async Task<IActionResult> UpdateRentCar([FromBody] UpdateRentCarDTO request)
        {
            try
            {
                var rentCar = await _carSharingService.UpdateRentCar(request);
                return Json(rentCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("rent-car")]
        public async Task<IActionResult> DeleteRentCar([FromQuery] DeleteRentCarDTO request)
        {
            try
            {
                var isDeleted = await _carSharingService.DeleteRentCar(request);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("setup-car-sharing-builder-result")]
        public IActionResult SetupCarSharingBuilderResult()
        {
            try
            {
                var builderResult = _carSharingService.SetupCarSharingBuilderResult();
                return Json(builderResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("get-all-cars-of-car-sharing")]
        public async Task<IActionResult> GetAllCarsOfCarSharing([FromBody] CarSharingBuilderResult builder, [FromQuery] Guid id)
        {
            try
            {
                var stepOneResult = await _carSharingService.GetAllCarsOfCarSharing(builder, id);
                return Json(stepOneResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("get-car-rent-periods")]
        public async Task<IActionResult> GetCarRentPeriods([FromBody] CarSharingBuilderResult builder, [FromQuery] Guid id)
        {
            try
            {
                var stepTwoResult = await _carSharingService.GetCarReservedPeriods(builder, id);
                return Json(stepTwoResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("check-rent")]
        public async Task<IActionResult> CheckRent([FromBody] CarSharingBuilderResult builder, [FromQuery] PeriodModelDTO period)
        {
            try
            {
                var stepThreeResult = await _carSharingService.CheckRent(builder, period);
                return Ok(stepThreeResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCarSharings()
        {
            try
            {
                var carSharings = await _carSharingService.GetAllCarSharings();
                return Json(carSharings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-rent-cars")]
        public IActionResult GetAllRentCars()
        {
            try
            {
                var rentCars = _carSharingService.GetAllRentCars();
                return Json(rentCars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("rent-a-car")]
        public IActionResult RentACar([FromBody] CarSharingBuilderResult builder)
        {
            try
            {
                var car = _carSharingService.RentACar(builder);
                return Json(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}