﻿using CityWeb.Domain.DTO;
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

namespace CityWeb.Infrastructure.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public DeliveryService(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DeliveryModelDTO> CreateDeliveryCompany(CreateDeliveryModelDTO deliveryModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == deliveryModel.Title);
            if(delivery == null)
            {
                try
                {
                    var newDelivery = _mapper.Map<CreateDeliveryModelDTO, DeliveryModel>(deliveryModel);
                    newDelivery.DeliveryAdress = _mapper.Map<AddressModelDTO, AddressModel>(deliveryModel.DeliveryAdress);
                    newDelivery.Service = new ServiceModel();
                    newDelivery.DeliveryPrice = _mapper.Map<PriceModelDTO, PriceModel>(deliveryModel.DeliveryPrice);
                    newDelivery.WorkSchedule = _mapper.Map<PeriodModelDTO, PeriodModel>(deliveryModel.WorkSchedule);
                    await _context.Deliveries.AddAsync(newDelivery);
                    await _context.SaveChangesAsync();
                    var result = _mapper.Map<DeliveryModel, DeliveryModelDTO>(newDelivery);
                    result.WorkShedyle = _mapper.Map<PeriodModel, PeriodModelDTO>(newDelivery.WorkSchedule);
                    result.DeliveryPrice = _mapper.Map<PriceModel, PriceModelDTO>(newDelivery.DeliveryPrice);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            throw new Exception("Company was already created");
        }

        public async Task<DeliveryModelDTO> UpdateDeliveryCompany(UpdateDeliveryModelDTO deliveryModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == deliveryModel.Title);
            if (delivery != null)
            {
                delivery = _mapper.Map<UpdateDeliveryModelDTO, DeliveryModel>(deliveryModel, delivery);
                delivery.DeliveryPrice = _mapper.Map<PriceModelDTO, PriceModel>(deliveryModel.DeliveryPrice, delivery.DeliveryPrice);
                delivery.WorkSchedule = _mapper.Map<PeriodModelDTO, PeriodModel>(deliveryModel.WorkShedyle, delivery.WorkSchedule);
                _context.Deliveries.Update(delivery);
                await _context.SaveChangesAsync();
                var updateDelivery = _mapper.Map<DeliveryModel, DeliveryModelDTO>(delivery);
                updateDelivery.DeliveryPrice = _mapper.Map<PriceModel, PriceModelDTO>(delivery.DeliveryPrice);
                updateDelivery.WorkShedyle = _mapper.Map<PeriodModel, PeriodModelDTO>(delivery.WorkSchedule);
                return updateDelivery;
            }
            throw new Exception("Company does not exist!");
        }

        public async Task<bool> DeleteDeliveryCompany(DeleteCompanyDTO dtoModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == dtoModel.Title);
            if (delivery != null)
            {
                _context.Remove(delivery);
                _context.SaveChanges();
                return true;
            }
            throw new Exception("Company does not exist!");
        }
        public async Task<CreateProductDTO> CreateProduct(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.Title);
            if (delivery != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName && x.DeliveryId == delivery.Id);
                if (product == null)
                {
                    product = _mapper.Map<ProductModelDTO, ProductModel>(productModel);
                    product.ProductType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Name == productModel.ProductType);
                    product.ProductPrice = _mapper.Map<PriceModelDTO, PriceModel>(productModel.Price);
                    product.Delivery = delivery; 
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                    var result = _mapper.Map<ProductModel, CreateProductDTO>(product);
                    result.ProductType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Name == productModel.ProductType);
                    result.Price = _mapper.Map<PriceModel, PriceModelDTO>(product.ProductPrice);
                    return result;
                }
                throw new Exception("Product was already created!");
            }
            throw new Exception("Company was not created!");
        }

        public async Task<ProductUpdateDTO> UpdateProduct(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.Title);
            if (delivery != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName && x.DeliveryId == delivery.Id) ;
                if (product != null)
                {
                    product = _mapper.Map<ProductModelDTO, ProductModel>(productModel, product);
                    product.ProductType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Name == productModel.ProductType);
                    product.ProductPrice = _mapper.Map<PriceModelDTO, PriceModel>(productModel.Price, product.ProductPrice);
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    var updateProduct = _mapper.Map<ProductModel, ProductUpdateDTO>(product);
                    updateProduct.Price = _mapper.Map<PriceModel, PriceModelDTO>(product.ProductPrice);
                    return updateProduct;
                }
                throw new Exception("Product was not created!");
            }
            throw new Exception("Company was not created!");
        }

        public async Task<bool> DeleteProduct(DeleteProductDTO dtoModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == dtoModel.Title);
            if(delivery != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == dtoModel.ProductName && x.DeliveryId == delivery.Id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("Product does not exist!");
            }
            throw new Exception("Company does not exist!");
        }

        public async Task<ICollection<DeliveryModelDTO>> GetAllDelivery(int skip = 0, int take = 10)
        {
            return await _context.Deliveries.Skip(skip).Take(take).Select(x => _mapper.Map<DeliveryModel, DeliveryModelDTO>(x)).ToListAsync();
        }

        public async Task<ICollection<ProductModelDTO>> GetAllProductByDeliveryName(DeliveryNameDTO deliveryName)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == deliveryName.Title);
            if (delivery != null)
            {
                return await _context.Products.Where(x => x.DeliveryId == delivery.Id).Select(x => _mapper.Map<ProductModel, ProductModelDTO>(x)).ToListAsync();
            }
            throw new Exception("Company does not exist!");
        }

        public async Task<ICollection<ProductModelDTO>> GetAllProductByPriceFilter(ProductPriceFilterDTO priceFilter, int skip = 0, int take = 10)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == priceFilter.Title);
            if (delivery != null)
            {
                var result = await _context.Products.Where(x => x.DeliveryId == delivery.Id && x.ProductPrice.Total >= priceFilter.MinPrice && x.ProductPrice.Total <= priceFilter.MaxPrice)
                    .Select(x => _mapper.Map<ProductModel, ProductModelDTO>(x)).ToListAsync();
                return result;
            }
            throw new Exception("Company does not exist!");
        }

        // Methods for steps
        public IEnumerable<SelectDeliveryModelDTO> ShowWorkingCompany(DeliveryCompanySheduleDTO companyShedule)
        {
            var delivery = _context.Deliveries.Where(x => 
                x.WorkSchedule.StartTime.TimeOfDay < companyShedule.WorkTime.TimeOfDay &&
                x.WorkSchedule.EndTime.TimeOfDay > companyShedule.WorkTime.TimeOfDay);
            return delivery.Select(x => _mapper.Map<DeliveryModel, SelectDeliveryModelDTO>(x));
        }
        
        public async Task<ICollection<string>> SelectDeliveryCompany(SelectDeliveryModelDTO dtoModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => dtoModel.Title == x.Title );
            return await _context.Products.Where(x => x.DeliveryId == delivery.Id).Select(x => x.ProductType.Name).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<ProductModelDTO>> GetProductsByType(ProductByTypeDTO dtoModel)
        {
            var result = await _context.Products.Where(x => x.ProductType.Name == dtoModel.TypeName).
                Select(x => _mapper.Map<ProductModel, ProductModelDTO>(x)).ToListAsync();
            return result;
        }

        public async Task<PaymentModelDTO> CheckoutBusket(BusketModelDTO busketModelDTO)
        {
            var productIds = busketModelDTO.Busket.Select(x => x.ProductId);
            var products = _context.Products.Where(x => productIds.Contains(x.Id));
            var price = await products.SumAsync(x => x.ProductPrice.Total * busketModelDTO.Busket.FirstOrDefault(z => z.ProductId == x.Id).Quantity);
            
            return new PaymentModelDTO()
            {
                TotalPrice = price
            };
        }
    }

}
