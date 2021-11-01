using CityWeb.Domain.DTO;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Infrastructure.Interfaces.Service;
using CityWeb.Domain.DTO.DeliveryDTO;
using CityWeb.Domain.Entities;

namespace CityWeb.Infrastructure.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ApplicationContext _context;
        public DeliveryService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeliveryModel> CreateDeliveryCompany(CreateDeliveryModelDTO deliveryModel)
        {
            try
            {
                var model = deliveryModel.CreateFromDTO();
                await _context.Deliveries.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeliveryModelDTO> UpdateDeliveryCompany(UpdateDeliveryModelDTO deliveryModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == deliveryModel.Title);
            if (delivery != null)
            {
                delivery.UpdateFromDTO(deliveryModel);
                _context.Deliveries.Update(delivery);
                await _context.SaveChangesAsync();
                return delivery.ToDeliveryModelDTO();
            }
            else
            {
                throw new Exception("Company does not exist!");
            }
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
            else
            {
                throw new Exception("Company does not exist!");
            }
        }
        public async Task<CreateProductDTO> CreateProduct(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.Title);
            if (delivery != null)
            {
                var checkProductName = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName && x.DeliveryId == delivery.Id);
                if (checkProductName == null)
                {
                    var product = delivery.CreateProductFromDTO(productModel);
                    var model = await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                    return model.Entity.ToCreateProductDTO();
                }
                else
                {
                    throw new Exception("Product was already created!");
                }
            }
            else
            {
                throw new Exception("Company was not created!");
            }
        }

        public async Task<ProductUpdateDTO> UpdateProduct(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.Title);
            if (delivery != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName && x.DeliveryId == delivery.Id) ;
                if (product != null)
                {
                    product.UpdateProductFromDTO(productModel);
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return product.ToProductUpdateDTO();
                }
                else
                {
                    throw new Exception("Product was not created!");
                }
            }
            else
            {
                throw new Exception("Company was not created!");
            }
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
                else
                {
                    throw new Exception("Product does not exist!");
                }
            }
            else
            {
                throw new Exception("Company does not exist!");
            }
        }

        public async Task<ICollection<DeliveryModelDTO>> GetAllDelivery()
        {
            return await _context.Deliveries.Select(x => x.ToDeliveryModelDTO()).ToListAsync();
        }

        public IEnumerable<DeliveryModelDTO> GetDeliveries(int skip = 0, int take = 10)
        {
            return _context.Deliveries.Skip(skip).Take(take).Select(x => x.ToDeliveryModelDTO());
        }

        // Methods for steps
        public IEnumerable<SelectDeliveryModelDTO> ShowWorkingCompany(DeliveryCompanySheduleDTO companyShedule)
        {
            var delivery = _context.Deliveries.Where(x => 
                x.WorkSchedule.StartTime.TimeOfDay < companyShedule.WorkTime.TimeOfDay &&
                x.WorkSchedule.EndTime.TimeOfDay > companyShedule.WorkTime.TimeOfDay);
            return delivery.Select(x => x.ToSelectDeliveryModelDTO());
        }
        
        public async Task<IEnumerable<string>> SelectDeliveryCompany(SelectDeliveryModelDTO dtoModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => dtoModel.Title == x.Title );
            return delivery.Products.Select(x => x.ProductType.Name);
        }

        public IEnumerable<ProductModelDTO> GetProductsByType(ProductByTypeDTO dtoModel)
        {
            var products = _context.Products.Where(x => dtoModel.ProductName == x.ProductName && x.ProductType.Name == dtoModel.TypeName).Distinct();
            return products.Select(x => x.ToProductDTO());
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
