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
        /*
        [HttpPost("product")]
        public async Task<IActionResult> CreateMenu([FromBody] ProductModelDTO request)
        {
            try
            {
                var product = await _deliveryService.CreateProduct(request);
                return Json(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("product")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModelDTO request)
        {
            try
            {
                var product = await _deliveryService.UpdateProduct(request);
                return Json(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("product")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductDTO request)
        {
            try
            {
                var isDeleted = await _deliveryService.DeleteProduct(request);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("step-one")]
        public async Task<IActionResult> ShowWorkingCompany([FromBody] DeliveryCompanySheduleDTO request)
        {
            try
            {
                var workingCompany = _deliveryService.ShowWorkingCompany(request);
                return Json(workingCompany);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("step-two")]
        public async Task<IActionResult> SelectDeliveryCompany([FromBody] SelectDeliveryModelDTO request)
        {
            try
            {
                var delivery = _deliveryService.SelectDeliveryCompany(request);
                return Ok(delivery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("step-three")]
        public async Task<IActionResult> GetProductsByType([FromBody] ProductByTypeDTO request)
        {
            try
            {
                var product = _deliveryService.GetProductsByType(request);
                return Json(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("step-four")]
        public async Task<IActionResult> CheckoutBusket([FromBody] BusketModelDTO request)
        {
            try
            {
                var product = await _deliveryService.CheckoutBusket(request);
                return Json(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllDelivery()
        {
            try
            {
                var deliverys = _deliveryService.GetAllDelivery();
                return Json(deliverys);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}
