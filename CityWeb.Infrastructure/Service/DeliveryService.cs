using CityWeb.Domain.DTO;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Infrastructure.Interfaces.Service;
using CityWeb.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using CityWeb.Domain.Enums;

namespace CityWeb.Infrastructure.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DeliveryService> _logger;
        public DeliveryService(ApplicationContext context, IMapper mapper, ILogger<DeliveryService> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<DeliveryModelDTO> CreateDeliveryCompany(CreateDeliveryModelDTO deliveryModel)
        {
            var delivery = await _context.Deliveries.AnyAsync(x => x.Title == deliveryModel.Title);
            if(!delivery)
            {
                try
                {
                    var newDelivery = _mapper.Map<CreateDeliveryModelDTO, DeliveryModel>(deliveryModel);
                    newDelivery.Service = new ServiceModel();
                    await _context.Deliveries.AddAsync(newDelivery);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Delivery company {newDelivery.Title} was created");

                    return _mapper.Map<DeliveryModel, DeliveryModelDTO>(newDelivery); 
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            _logger.LogError($"Company {deliveryModel.Title} was already created");
            throw new Exception("Company was already created");
        }

        public async Task<DeliveryModelDTO> UpdateDeliveryCompany(UpdateDeliveryModelDTO deliveryModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == deliveryModel.Id);
            if (delivery != null)
            {
                try
                {
                    delivery = _mapper.Map<UpdateDeliveryModelDTO, DeliveryModel>(deliveryModel, delivery);
                    _context.Deliveries.Update(delivery);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Delivery company {delivery.Title} was updated");

                    return _mapper.Map<DeliveryModel, DeliveryModelDTO>(delivery);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                } 
            }
            _logger.LogError($"Company {deliveryModel.Id} does not exist!");
            throw new Exception("Company does not exist!");
        }

        public async Task<bool> DeleteDeliveryCompany(DeleteCompanyDTO deleteModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == deleteModel.DeliveryId);
            if (delivery != null)
            {
                try
                {
                    _context.Remove(delivery);
                    _context.SaveChanges();

                    _logger.LogInformation($"Delivery company {delivery.Title} was deleted");

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            _logger.LogError($"Company {deleteModel.DeliveryId} does not exist!");
            throw new Exception("Company does not exist!");
        }

        public async Task<ProductModelDTO> CreateProduct(CreateProductModelDTO createProductDTO)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == createProductDTO.DeliveryId);
            if (delivery != null)
            {
                var isExistProduct = await _context.Products.AnyAsync(x => x.ProductName == createProductDTO.ProductName && x.DeliveryId == delivery.Id);
                if (!isExistProduct)
                {
                    try
                    {
                        var newProduct = _mapper.Map<CreateProductModelDTO, ProductModel>(createProductDTO);
                        newProduct.Delivery = delivery;
                        await _context.Products.AddAsync(newProduct);
                        await _context.SaveChangesAsync();

                        _logger.LogInformation($"Product {createProductDTO.ProductName} was created");

                        return _mapper.Map<ProductModel, ProductModelDTO>(newProduct);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        throw new Exception(ex.Message);
                    }
                }
                _logger.LogError($"Product {createProductDTO.ProductName} was already created!");
                throw new Exception("Product was already created!");
            }
            _logger.LogError($"Company {createProductDTO.DeliveryId} does not exist!");
            throw new Exception("Company does not exist!");
        }

        public async Task<ProductModelDTO> UpdateProduct(UpdateProductModelDTO updateProductDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == updateProductDTO.ProductId);
            if (product != null)
            {
                try
                {
                    product = _mapper.Map<UpdateProductModelDTO, ProductModel>(updateProductDTO, product);
                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Product {updateProductDTO.ProductId} was updated");

                    return _mapper.Map<ProductModel, ProductModelDTO>(product);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            _logger.LogError($"Product {updateProductDTO.ProductName} does not exist!");
            throw new Exception("Product does not exist!");
        }

        public async Task<bool> DeleteProduct(DeleteProductDTO deleteProductDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == deleteProductDTO.ProductId);
            if (product != null)
            {
                try
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    _logger.LogInformation($"Product {deleteProductDTO.ProductId} was deleted");
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }   
            }
            _logger.LogError($"Product {deleteProductDTO.ProductId} does not exist!");
            throw new Exception("Product does not exist!");
        }

        public async Task<ICollection<DeliveryModelDTO>> GetAllDelivery(int skip = 0, int take = 10)
        {
            try
            {
                return await _context.Deliveries.Skip(skip).Take(take).Select(x => _mapper.Map<DeliveryModel, DeliveryModelDTO>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            } 
        }

        public async Task<ICollection<ProductModelDTO>> GetAllProductByDeliveryId(DeliveryIdDTO deliveryIdDTO)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == deliveryIdDTO.DeliveryId);
            try
            {
                if (delivery != null)
                {
                    var result = await _context.Products.Where(x => x.DeliveryId == delivery.Id).Select(x => _mapper.Map<ProductModel, ProductModelDTO>(x)).ToListAsync();
                    _logger.LogInformation($"Received all products for delivery company with id:{deliveryIdDTO.DeliveryId}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            _logger.LogError("Company does not exist!");
            throw new Exception("Company does not exist!");
        }

        public async Task<ICollection<ProductModelDTO>> GetAllProductByPriceFilter(ProductPriceFilterDTO priceFilter, int skip = 0, int take = 10)
        {
            var delivery = await _context.Deliveries.AnyAsync(x => x.Id == priceFilter.DeliveryId);
            if (delivery)
            {
                try
                {
                    var result = await _context.Products.Where(x => x.DeliveryId == priceFilter.DeliveryId && x.ProductPrice.Total >= priceFilter.MinPrice && x.ProductPrice.Total <= priceFilter.MaxPrice)
                   .Select(x => _mapper.Map<ProductModel, ProductModelDTO>(x)).ToListAsync();
                    _logger.LogInformation($"Received all products for delivery company with id:{priceFilter.DeliveryId} using price filter");
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            _logger.LogError("Company does not exist!");
            throw new Exception("Company does not exist!");
        }

        // Methods for steps
        public IEnumerable<SelectDeliveryModelDTO> ShowWorkingCompany(DeliveryCompanySheduleDTO companyShedule)
        {
            try
            {
                var delivery = _context.Deliveries.Where(x =>
                x.WorkSchedule.StartTime.TimeOfDay < companyShedule.WorkTime.TimeOfDay &&
                x.WorkSchedule.EndTime.TimeOfDay > companyShedule.WorkTime.TimeOfDay);
                _logger.LogInformation("Show all working delivery company in this time");
                return delivery.Select(x => _mapper.Map<DeliveryModel, SelectDeliveryModelDTO>(x));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<ICollection<string>> SelectDeliveryCompany(SelectDeliveryModelDTO dtoModel)
        {
            try
            {
                return await _context.Products.Where(x => x.DeliveryId == dtoModel.DeliveryId).Select(x => x.ProductType.ToString()).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            } 
        }

        public async Task<IEnumerable<ProductModelDTO>> GetProductsByType(ProductByTypeDTO dtoModel)
        {
            try
            {
                var result = await _context.Products.Where(x => x.ProductType.ToString() == dtoModel.TypeName).
                                Select(x => _mapper.Map<ProductModel, ProductModelDTO>(x)).ToListAsync();
                _logger.LogInformation("Shown all product with carent product type");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaymentModelDTO> CheckoutBusket(BusketModelDTO busketModelDTO)
        {
            try
            {
                var productIds = busketModelDTO.Busket.Select(x => x.ProductId);
                var products = _context.Products.Where(x => productIds.Contains(x.Id));
                var price = await products.SumAsync(x => x.ProductPrice.Total * busketModelDTO.Busket.FirstOrDefault(z => z.ProductId == x.Id).Quantity);
                _logger.LogInformation($"Product with id {busketModelDTO.Busket.Select(x => x.ProductId)} add to basket");

                return new PaymentModelDTO()
                {
                    TotalPrice = price
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }

}
