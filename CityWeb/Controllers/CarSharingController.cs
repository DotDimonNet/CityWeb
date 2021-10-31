using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Interfaces;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Taste.Web.Controllers
{
    [ApiController]
    [Route("api/carSharing")]
    public class CarSharingController : Controller
    {
        private readonly ICarSharingService _carSharingService;

        public CarSharingController(ICarSharingService carSharingService)
        {
            _carSharingService = carSharingService;
        }

        [HttpPost("createCarSharing")]
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

        [HttpPost("updateCarSharing")]
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

        [HttpPost("deleteCarSharing")]
        public async Task<IActionResult> DeleteCarSharing([FromBody] DeleteCarSharingModelDTO request)
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

        [HttpPost("addRentCar")]
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

        [HttpPost("updateRentCar")]
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

        [HttpPost("deleteRentCar")]
        public async Task<IActionResult> DeleteRentCar([FromBody] DeleteRentCarDTO request)
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

        [HttpPost("setupCarSharingBuilderResult")]
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

        /*[HttpPost("stepOne")]
        public async Task<IActionResult> StepOne([FromBody] CarSharingBuilderResult builder, string title)
        {
            try
            {
                var stepOneResult = await _carSharingService.StepOne(builder, title);
                return Json(stepOneResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        /*[HttpPost("stepTwo")]
        public async Task<IActionResult> StepTwo([FromBody] CarSharingBuilderResult builder, string vinCode)
        {
            try
            {
                var stepTwoResult = await _carSharingService.StepTwo(builder, vinCode);
                return Json(stepTwoResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        /*[HttpPost("stepThree")]
        public async Task<IActionResult> StepThree([FromBody] CarSharingBuilderResult builder, PeriodModel period)
        {
            try
            {
                var stepThreeResult = await _carSharingService.StepThree(builder, period);
                return Ok(stepThreeResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpPost("getAllCarSharings")]
        public IActionResult GetAllCarSharings()
        {
            try
            {
                var carSharings = _carSharingService.GetAllCarSharings();
                return Json(carSharings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("getAllRentCars")]
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
    }
}