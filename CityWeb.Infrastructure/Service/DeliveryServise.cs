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


namespace CityWeb.Infrastructure.Service
{
    public class DeliveryServise
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        public DeliveryServise(ApplicationContext context, SignInManager<ApplicationUserModel> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<DeliveryModel> CreateDeliveryCompany(DeliveryModelDTO deliveryModel)
        {
            var delivery = new DeliveryModel()
            {
                Title = deliveryModel.Title,
                Description = deliveryModel.Description,
            };
     
               return await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == deliveryModel.Title);
   
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

        public async Task<ProductPriceDTO> UpdateProduct(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.Title);
            if(delivery != null)
            {
                var product = await _context.Orders.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName);
                if (product != null)
                {
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

        public async Task<CreateProductDTO> CreateMeny(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.Title);
            if (delivery != null)
            {
                var product = await _context.Orders.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName);
                if (product == null)
                {
                    product.ProductName = productModel.ProductName;
                    product.ProductPrice.Value = productModel.Value;
                    product.ProductPrice.VAT = productModel.VAT;
                    product.ProductPrice.Tax = productModel.Tax;

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return product.ToCreateProductDTO();
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

        public async Task DeleteProduct(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.ProductName);
            if (delivery != null)
            {
                var product = await _context.Orders.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName);
               
                _context.Orders.Remove(product);              
                _context.SaveChanges();
               
            }
            else
            {
                throw new Exception("Product was not created!");
            }
        }
    }

}
