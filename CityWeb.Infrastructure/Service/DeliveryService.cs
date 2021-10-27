using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Extentions;
using CityWeb.Domain.ValueTypes;

namespace CityWeb.Infrastructure.Service
{
    public class DeliveryService
    {
        private readonly ApplicationContext _context;
        public DeliveryService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeliveryModelDTO> CreateDeliveryCompany(CreateDeliveryModelDTO deliveryModel)
        {
            var delivery = new DeliveryModel()
            {
                Title = deliveryModel.Title,
                Description = deliveryModel.Description,
            };

            var model = await _context.Deliveries.AddAsync(delivery);
            _context.SaveChanges();
            return model.Entity.ToDeliveryModelDTO();
        }

        public IEnumerable<DeliveryModelDTO> GetDeliveries() 
        {
            return _context.Deliveries.Select(x => x.ToDeliveryModelDTO());
        }

        public async Task<DeliveryDTO> UpdateDeliveryCompany(UpdateDeliveryModelDTO deliveryModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == deliveryModel.Title);
            
            if (delivery != null)
            {
                delivery.Description = deliveryModel.Description;
                delivery.WorkSchedule.StartTime = deliveryModel.StartTime;
                delivery.WorkSchedule.EndTime = deliveryModel.EndTime;
                delivery.DeliveryPrice.Value = deliveryModel.Value;
                delivery.DeliveryPrice.Tax = deliveryModel.Tax;
                delivery.DeliveryPrice.VAT = deliveryModel.VAT;

                _context.Update(delivery);
                await _context.SaveChangesAsync();
                return delivery.ToDeliveryDTO();
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
                    product.ProductImage = productModel.ProductImage;
                    product.ProductType = productModel.ProductType;
                    product.ProductPrice.Value = productModel.Value;
                    product.ProductPrice.VAT = productModel.VAT;
                    product.ProductPrice.Tax = productModel.Tax;

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return product.ToProductPriceDTO();
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

        public async Task<CreateProductDTO> CreateMenu(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.Title);
            if (delivery != null)
            {
                var product = new ProductModel()
                        {
                            DeliveryId = delivery.Id,
                            ProductImage = productModel.ProductImage,
                            ProductName = productModel.ProductName,
                            ProductType = productModel.ProductType,
                            ProductPrice = new PriceModel() 
                            {
                               Value = productModel.Value,
                                VAT = productModel.VAT,
                                Tax = productModel.Tax,
                            } 
                        };

                    var model = await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                    return model.Entity.ToCreateProductDTO();
               
            }
            else
            {
                throw new Exception("Company was not created!");
            }
        }

        public async Task DeleteDeliveryCompany(DeleteCompanyDTO dtoModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == dtoModel.CompanyId);
            if (delivery != null)
            {
                _context.Remove(delivery);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Company does not exist!");
            }
        }

        public async Task DeleteProduct(DeleteProductDTO dtoModel)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == dtoModel.ProductId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product does not exist!");
            }
        }

        
        public IEnumerable<SelectDeliveryModelDTO> ShowWorkingCompany(DeliveryCompanySheduleDTO companyShedule)
        {
            var delivery = _context.Deliveries.Where(x => x.WorkSchedule.StartTime.TimeOfDay < companyShedule.WorkTime.TimeOfDay && x.WorkSchedule.EndTime.TimeOfDay > companyShedule.WorkTime.TimeOfDay);
            return delivery.Select(x => x.ToSelectDeliveryModelDTO());
        }
        
        public async Task<IEnumerable<string>> SelectDeliveryCompany(SelectDeliveryModelDTO dtoModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => dtoModel.DeliveryId == x.Id );

            return delivery.Products.Select(x => x.ProductType.Name);
        }

        public IEnumerable<ProductModelDTO> GetProductsByType(ProductByTypeDTO dtoModel)
        {
            var products = _context.Products.Where(x => dtoModel.DeliveryId == x.DeliveryId && x.ProductType.Name == dtoModel.TypeName).Distinct();

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
