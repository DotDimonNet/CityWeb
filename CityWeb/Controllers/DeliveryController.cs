using CityWeb.Domain.DTO;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Controllers
{
    [ApiController]
    [Route("api/Delivery")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost("delivery")]
        public async Task<IActionResult> CreateDelivery([FromBody] CreateDeliveryModelDTO request)
        {
            try
            {
                var delivery = await _deliveryService.CreateDeliveryCompany(request);
                return Json(delivery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("delivery")]
        public async Task<IActionResult> UpdateDelivery([FromBody] UpdateDeliveryModelDTO request)
        {
            try
            {
                var delivery = await _deliveryService.UpdateDeliveryCompany(request);
                return Json(delivery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delivery")]
        public async Task<IActionResult> DeleteDelivery([FromBody] DeleteCompanyDTO request)
        {
            try
            {
                var isDeleted = await _deliveryService.DeleteDeliveryCompany(request);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
                var product = _deliveryService.CheckoutBusket(request);
                return Json(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetDeliveries(int skip = 0, int take = 10)
        {
            try
            {
                var deliverys = _deliveryService.GetDeliveries();
                return Json(deliverys);
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
        }
    }
}
