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
    [Route("api/delivery")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost]
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

        [HttpPut]
        public async Task<IActionResult> UpdateDelivery([FromBody] UpdateDeliveryModelDTO request, [FromQuery] Guid id)
        {
            try
            {
                var delivery = await _deliveryService.UpdateDeliveryCompany(request, id);
                return Json(delivery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDelivery([FromQuery] Guid id)
        {
            try
            {
                var isDeleted = await _deliveryService.DeleteDeliveryCompany(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductModelDTO request, [FromQuery] Guid deliveryId)
        {
            try
            {
                var product = await _deliveryService.CreateProduct(request, deliveryId);
                return Json(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("product")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductModelDTO request)
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
                return Ok(delivery.Result);
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
                return Json(product.Result);
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

        [HttpGet("deliveries")]
        public IActionResult GetAllDelivery()
        {
            try
            {
                var deliveries = _deliveryService.GetAllDelivery();
                return Json(deliveries.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("by-id")]
        public IActionResult GetDeliveryById([FromQuery] Guid id )
        {
            try
            {
                var delivery = _deliveryService.GetDeliveryById(id);
                return Json(delivery.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("products")]
        public IActionResult GetAllProductByDeliveryId([FromQuery] Guid id)
        {
            try
            {
                var products = _deliveryService.GetAllProductByDeliveryId(id);
                return Json(products.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("products-by-price-filter")]
        public IActionResult GetAllProductByPriceFilter([FromQuery] ProductPriceFilterDTO request)
        {
            try
            {
                var products = _deliveryService.GetAllProductByPriceFilter(request);
                return Json(products.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
