using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class DeliveryServiceTests
    {
        private ILogger<DeliveryService> _logger;
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _logger = TestHelper.SetupTestLogger<DeliveryService>();
        }

        [Test]
        public async Task CreateDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new CreateDeliveryModelDTO()
            {
                Title = "Delivery Company",
                Description = "Default description",
                DeliveryAdress = new AddressModelDTO(),
                DeliveryPrice = new PriceModelDTO(),
                WorkSchedule = new PeriodModelDTO(),
            };

            var delivery = await deliveryService.CreateDeliveryCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == delivery.Title);

            Assert.IsNotNull(delivery);
            Assert.AreEqual(delivery.Description, deliveryFromContext.Description);
            Assert.AreEqual(delivery.Title, deliveryFromContext.Title);
        }

        [Test]
        public async Task UpdateDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var deliveryId = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == "DeliveryCompany2");
            var dto = new UpdateDeliveryModelDTO()
            {
                Id = deliveryId.Id,
                Description = "Super quick",
                WorkSchedule = new PeriodModelDTO()
                {
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                },
                DeliveryPrice = new PriceModelDTO()
                {
                    Value = 10.00,
                    Tax = 0.00,
                    VAT = 2.00,
                },
            };
            var delivery = await deliveryService.UpdateDeliveryCompany(dto);

            Assert.IsNotNull(delivery);
            Assert.AreEqual(delivery.Description, deliveryId.Description);
            Assert.AreEqual(delivery.WorkSchedule.StartTime, deliveryId.WorkSchedule.StartTime);
            Assert.AreEqual(delivery.WorkSchedule.EndTime, deliveryId.WorkSchedule.EndTime);
            Assert.AreEqual(delivery.DeliveryPrice.Value, deliveryId.DeliveryPrice.Value);
        }

        [Test]
        public async Task UpdateDeliveryCompanyExceptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new UpdateDeliveryModelDTO()
            {
                Id = Guid.NewGuid(),
                DeliveryPrice = new PriceModelDTO()
                {
                    Value = 10.00,
                    Tax = 0.00,
                    VAT = 2.00,
                },
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.UpdateDeliveryCompany(dto));
            Assert.AreEqual(exeption.Message, "Company does not exist!");
        }

        [Test]
        public async Task DeleteDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var deliveryId = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == "DeliveryCompany6");
            var dto = new DeleteCompanyDTO()
            {
                DeliveryId = deliveryId.Id,
            };

            await deliveryService.DeleteDeliveryCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Id == dto.DeliveryId);
            Assert.IsNull(deliveryFromContext);
        }

        [Test]
        public async Task DeleteDeliveryCompanyExceptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new DeleteCompanyDTO()
            {
                DeliveryId = Guid.NewGuid(),
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.DeleteDeliveryCompany(dto));
            Assert.AreEqual(exeption.Message, "Company does not exist!");
        }

        [Test]
        public async Task CreateProductTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var deliveryId = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == "DeliveryCompany2");
            var dto = new CreateProductModelDTO()
            {
                DeliveryId = deliveryId.Id,
                ProductName = "Product",
                ProductType = "Burgers",
                ProductImage = "img",
                ProductPrice = new PriceModelDTO()
                {
                    Value = 10.00,
                    Tax = 0.00,
                    VAT = 2.00,
                },
            };

            var product = await deliveryService.CreateProduct(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == product.ProductName);

            Assert.IsNotNull(product);
            Assert.AreEqual(product.ProductName, productFromContext.ProductName);
            Assert.AreEqual(product.ProductType, productFromContext.ProductType.ToString());
            Assert.AreEqual(product.ProductImage, productFromContext.ProductImage);
            Assert.AreEqual(product.ProductPrice.VAT, productFromContext.ProductPrice.VAT);
            Assert.AreEqual(product.ProductPrice.Tax, productFromContext.ProductPrice.Tax);
            Assert.AreEqual(product.ProductPrice.Value, productFromContext.ProductPrice.Value);
        }

        [Test]
        public async Task CreateProductExceptionOneTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new CreateProductModelDTO()
            {
                DeliveryId = Guid.NewGuid(),
                ProductName = "Product",
                ProductType = "Burgers",
                ProductImage = "img",
                ProductPrice = new PriceModelDTO()
                {
                    Value = 10.00,
                    Tax = 0.00,
                    VAT = 2.00,
                },
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.CreateProduct(dto));
            Assert.AreEqual(exeption.Message, "Company does not exist!");
        }

        [Test]
        public async Task CreateProductExceptionTwoTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var deliveryId = await TestHelper.ApplicationContext.Deliveries.FirstOrDefaultAsync(x => x.Title == "DeliveryCompany2");
            var dto = new CreateProductModelDTO()
            {
                DeliveryId = deliveryId.Id,
                ProductName = "Product2",
                ProductType = "Burgers",
                ProductImage = "img",
                ProductPrice = new PriceModelDTO()
                {
                    Value = 10.00,
                    Tax = 0.00,
                    VAT = 2.00,
                },
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.CreateProduct(dto));
            Assert.AreEqual(exeption.Message, "Product was already created!");
        }

        [Test]
        public async Task UpdateProductTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var productId = await TestHelper.ApplicationContext.Products.FirstOrDefaultAsync(x => x.ProductName == "Product1");
            var dto = new UpdateProductModelDTO()
            {
                ProductId = productId.Id,
                ProductName = "Product1",
                ProductPrice = new PriceModelDTO()
                {
                    Value = 10.00,
                },
            };

            var product = await deliveryService.UpdateProduct(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.Id == dto.ProductId);
            Assert.IsNotNull(product);
            Assert.AreEqual(product.ProductPrice.Value, productFromContext.ProductPrice.Value);
        }

        [Test]
        public async Task UpdateProductExceptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new UpdateProductModelDTO()
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Product1",
                ProductPrice = new PriceModelDTO()
                {
                    Value = 10.00,
                },
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.UpdateProduct(dto));
            Assert.AreEqual(exeption.Message, "Product does not exist!");
        }

        [Test]
        public async Task DeleteProductTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var productId = await TestHelper.ApplicationContext.Products.FirstOrDefaultAsync(x => x.ProductName == "Product6");
            var dto = new DeleteProductDTO()
            {
                ProductId = productId.Id
            };

            await deliveryService.DeleteProduct(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.Id == dto.ProductId);
            Assert.IsNull(productFromContext);
        }

        [Test]
        public async Task DeleteProductExceptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new DeleteProductDTO()
            {
                ProductId = Guid.NewGuid(),
            };
            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.DeleteProduct(dto));
            Assert.AreEqual(exeption.Message, "Product does not exist!");
        }

        [Test]
        public async Task ShowWorkingCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new DeliveryCompanySheduleDTO()
            {
                WorkTime = DateTime.Now,
            };

            deliveryService.ShowWorkingCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.Where(x => x.WorkSchedule.StartTime < dto.WorkTime && x.WorkSchedule.EndTime > dto.WorkTime).Count();
            Assert.IsTrue(deliveryFromContext == 10);
        }

        [Test]
        public async Task SelectDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var deliveryId = await TestHelper.ApplicationContext.Deliveries.FirstOrDefaultAsync(x => x.Title == "DeliveryCompany2");
            var dto = new SelectDeliveryModelDTO()
            {
                DeliveryId = deliveryId.Id,
            };

            var productType = deliveryService.SelectDeliveryCompany(dto);
            var delivery = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Id == dto.DeliveryId);
            var productTypeFromContext = delivery.Products.Select(x => x.ProductType.ToString());

            Assert.IsNotNull(productType);
            Assert.AreEqual(productType.Result, productTypeFromContext);
        }

        [Test]
        public async Task GetProductsByTypeTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new ProductByTypeDTO()
            {
                TypeName = "Burgers"
            };

            var products = await deliveryService.GetProductsByType(dto);
            var productsFromContextCount = TestHelper.ApplicationContext.Products.Where(x => x.ProductType.ToString() == dto.TypeName).Count();
            Assert.IsNotEmpty(products);
            Assert.AreEqual(productsFromContextCount, products.Count());
        }

        [Test]
        public async Task CheckoutBusketTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var productId = await TestHelper.ApplicationContext.Products.FirstOrDefaultAsync(x => x.ProductName == "Product2");
            var dto = new BusketModelDTO()
            {
                Busket =
                {
                    new BusketItemModelDTO()
                    {
                        ProductId = productId.Id,
                        Quantity = 5,
                    }
                },
                Address = new AddressModelDTO()
                {
                    StreetName = "Vatytina",
                    HouseNumber = "58",
                    ApartmentNumber = "101",
                },
                Name = "Volodya"
            };
            var busket = deliveryService.CheckoutBusket(dto);
            Assert.IsNotNull(busket);
        }

        [Test]
        public async Task GetAllDeliveryTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var deliverys = deliveryService.GetAllDelivery();
            var deliverysFromContext = await TestHelper.ApplicationContext.Deliveries.CountAsync();
            Assert.IsNotNull(deliverys);
            Assert.IsTrue(deliverysFromContext == 10);
        }

        [Test]
        public async Task GetAllProductByDeliveryIdTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var deliveryId = await TestHelper.ApplicationContext.Deliveries.FirstOrDefaultAsync(x => x.Title == "DeliveryCompany2");
            var dto = new DeliveryIdDTO()
            {
                DeliveryId = deliveryId.Id,
            };

            var product = deliveryService.GetAllProductByDeliveryId(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.Where(x => x.DeliveryId == dto.DeliveryId).Count();
            Assert.IsNotNull(product);
            Assert.IsTrue(productFromContext == 1);
        }

        [Test]
        public async Task GetAllProductByDeliveryIdExceptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new DeliveryIdDTO()
            {
                DeliveryId = Guid.NewGuid(),
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.GetAllProductByDeliveryId(dto));
            Assert.AreEqual(exeption.Message, "Company does not exist!");
        }

        [Test]
        public async Task GetAllProductByPriceFilterTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var deliveryId = await TestHelper.ApplicationContext.Deliveries.FirstOrDefaultAsync(x => x.Title == "DeliveryCompany2");
            var dto = new ProductPriceFilterDTO()
            {
                DeliveryId = deliveryId.Id,
                MinPrice = 0,
                MaxPrice = 1000,
            };

            var product = deliveryService.GetAllProductByPriceFilter(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.Where(x => x.DeliveryId == dto.DeliveryId &&
            x.ProductPrice.Value >= dto.MinPrice &&
            x.ProductPrice.Value <= dto.MaxPrice).Count();///TOTAL!!!!
            Assert.IsNotNull(product);
            Assert.IsTrue(productFromContext == 1);
        }

        [Test]
        public async Task GetAllProductByPriceFilterExceptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new ProductPriceFilterDTO()
            {
                DeliveryId = Guid.NewGuid(),
                MinPrice = 0,
                MaxPrice = 1000,
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.GetAllProductByPriceFilter(dto));
            Assert.AreEqual(exeption.Message, "Company does not exist!");
        }
    }
}