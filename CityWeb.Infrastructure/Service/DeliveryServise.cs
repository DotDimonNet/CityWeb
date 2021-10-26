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

        public async Task<ProductUpdateDTO> UpdateProduct(ProductModelDTO productModel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == productModel.Title);
            if(delivery != null)
            {
                var product = await _context.Orders.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName && x.DeliveryId == delivery.Id) ;
                if (product != null)
                {
                    product.ProductImage = productModel.ProductImage;
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
                var product = await _context.Orders.FirstOrDefaultAsync(x => x.ProductName == productModel.ProductName && x.DeliveryId == delivery.Id);
                if (product == null)
                {
                    delivery.Order.Add(
                        new ProductModel()
                        {
                            ProductImage = productModel.ProductImage,
                            ProductName = productModel.ProductName,
                            ProductPrice = new PriceModel() 
                            {
                               Value = productModel.Value,
                                VAT = productModel.VAT,
                                Tax = productModel.Tax,
                             } 
                        });

                    _context.Update(delivery);
                    await _context.SaveChangesAsync();
                    return product.ToCreateProductDTO();
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

        public async Task DeleteCompany (DeleteDTO delete)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == delete.Title);
            if (delivery != null)
            {
                _context.Remove(delivery);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Company was not created!");
            }
        }

        public async Task DeleteProduct(DeleteDTO delete)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == delete.Title);
            if (delivery != null)
            {
                var product = await _context.Orders.FirstOrDefaultAsync(x => x.ProductName == delete.ProductName);
                if (product != null)
                {
                    _context.Orders.Remove(product);
                    _context.SaveChanges();
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

        public async Task<PaymentModel> GetOrder(OrderModelDTO ordermodel)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == ordermodel.Title);
            if (delivery != null)
            {
                if(delivery.WorkSchedule.StartTime < DateTime.Now && delivery.WorkSchedule.EndTime > DateTime.Now)
                {
                    var product = await _context.Orders.FirstOrDefaultAsync(x => x.ProductName == ordermodel.ProductName);
                    var orderPrice = product.ProductPrice.Total * ordermodel.Count;
                    return new PaymentModel()
                    {
                        Title = ordermodel.ProductName,
                        Price = orderPrice,
                    };
                }
                else
                {
                    throw new Exception("Delivery is not available in this time!");
                }
            }
            else
            {
                throw new Exception("Delivery company is not found");
            }

        }

        //Builder

        public async Task<DeliveryBuilderResult> StepZero()
        {
            var builderResult = new DeliveryBuilderResult();
            //Front-end simulation
            foreach (var item in _context.Deliveries)
            {
                Console.WriteLine(item.DeliveryImage);
                Console.WriteLine(item.Title);
            }
            
            return builderResult;
        }

        public async Task<DeliveryBuilderResult> StepOne(DeliveryBuilderResult builderResult, string deliveryServiceTitle)
        {
            builderResult.DeliveryTitle = deliveryServiceTitle;

            var deliveryService = await _context.Deliveries.FirstOrDefaultAsync(x => x.Title == deliveryServiceTitle);
            
            //Front-end simulation
            foreach (var item in deliveryService.Order)
            {
                Console.WriteLine(item.ProductPrice);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductPrice.Total);
                Console.WriteLine(item.ProductCount);
            }
            return builderResult;
        }

        public async Task<DeliveryBuilderResult> StepTwo(DeliveryBuilderResult builderResult, string productImage, string productName, double productPrice, int productCount)
        {
            builderResult.ProductImage = productImage;
            builderResult.ProductName = productName;
            builderResult.ProductCount = productCount;
            builderResult.Price = productPrice;

            return builderResult;
        }

        
    }

}
