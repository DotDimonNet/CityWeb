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
        private Mock<ILogger<DeliveryService>> _loggerMock;
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _loggerMock = TestHelper.SetupTestLogger<DeliveryService>();
        }

        [Test]
        public async Task CreateDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
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
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
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
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Id == dto.Id);

            Assert.IsNotNull(delivery);
            Assert.AreEqual(delivery.Description, deliveryFromContext.Description);
            Assert.AreEqual(delivery.WorkSchedule.StartTime, deliveryFromContext.WorkSchedule.StartTime);
            Assert.AreEqual(delivery.WorkSchedule.EndTime, deliveryFromContext.WorkSchedule.EndTime);
            Assert.AreEqual(delivery.DeliveryPrice.Value, deliveryFromContext.DeliveryPrice.Value);
        }

        [Test]
        public async Task UpdateDeliveryCompanyExeptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            var deliveryId = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == "DeliveryCompany17");
            var dto = new UpdateDeliveryModelDTO()
            {
                Id = deliveryId.Id,// ?????
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
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
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
        public async Task DeleteDeliveryCompanyExeptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            var deliveryId = await TestHelper.ApplicationContext.Deliveries.FirstOrDefaultAsync(x => x.Title == "DeliveryCompany666");
            var dto = new DeleteCompanyDTO()
            {
                DeliveryId = deliveryId.Id
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.DeleteDeliveryCompany(dto));
            Assert.AreEqual(exeption.Message, "Company does not exist!");
        }

        [Test]
        public async Task CreateProductTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
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
            Assert.AreEqual(product.ProductType, productFromContext.ProductType);
            Assert.AreEqual(product.ProductImage, productFromContext.ProductImage);
            Assert.AreEqual(product.ProductPrice.VAT, productFromContext.ProductPrice.VAT);
            Assert.AreEqual(product.ProductPrice.Tax, productFromContext.ProductPrice.Tax);
            Assert.AreEqual(product.ProductPrice.Value, productFromContext.ProductPrice.Value);
        }

        [Test]
        public async Task CreateProductTestExeptionOneTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
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
        public async Task CreateProductExeptionTwoTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            var deliveryId = await TestHelper.ApplicationContext.Deliveries.FirstOrDefaultAsync(x => x.Title == "DeliveryCompany2");
            var dto = new CreateProductModelDTO()
            {
                DeliveryId = deliveryId.Id,
                ProductName = "Product2",
                //ProductType = ProductType.Burgers.ToString(),
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
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
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
        public async Task UpdateProductExeptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            var productId = await TestHelper.ApplicationContext.Products.FirstOrDefaultAsync(x => x.ProductName == "Product17");
            var dto = new UpdateProductModelDTO()
            {
                ProductId = productId.Id,
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
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
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
        public async Task DeleteProductExeptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            var productId = await TestHelper.ApplicationContext.Products.FirstOrDefaultAsync(x => x.ProductName == "Product66");
            var dto = new DeleteProductDTO()
            {
                ProductId = productId.Id
            };
            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.DeleteProduct(dto));
            Assert.AreEqual(exeption.Message, "Product does not exist!");
        }

        [Test]
        public async Task ShowWorkingCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
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
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            var deliveryId = await TestHelper.ApplicationContext.Deliveries.FirstOrDefaultAsync(x => x.Title == "DeliveryCompany2");
            var dto = new SelectDeliveryModelDTO()
            {
                DeliveryId = deliveryId.Id,
            };

            var productType = deliveryService.SelectDeliveryCompany(dto);
            var delivery = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Id == dto.DeliveryId);
            var productTypeFromContext = delivery.Products.Select(x => x.ProductType);

            Assert.IsNotNull(productType);
            Assert.AreEqual(productType.Result, productTypeFromContext);
        }

        //[Test]
        //public async Task GetProductsByTypeTest()
        //{
        //    var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper);
        //    var dto = new ProductByTypeDTO()
        //    {
        //        ProductName = "Product1",
        //        TypeName = "AlcoholicDrinks"
        //    };

        //    var product = deliveryService.GetProductsByType(dto);
        //    var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == dto.ProductName && x.ProductType.Name == dto.TypeName);
        //    Assert.IsNotNull(product);
        //    foreach (var item in product)
        //    {
        //        Assert.AreEqual(item.ProductName, productFromContext.ProductName);
        //        Assert.AreEqual(item.ProductImage, productFromContext.ProductImage);
        //        Assert.AreEqual(item.Price.Value, productFromContext.ProductPrice.Value);
        //    }
        //}

        //[Test]
        //public async Task CheckoutBusketTest()
        //{
        //    var deliveryService = new DeliveryService(TestHelper.ApplicationContext, TestHelper.TestMapper);
        //    var dto = new BusketModelDTO()
        //    {
        //        Busket =
        //        {
        //            new BusketItemModelDTO()
        //            {
        //                ProductId = Guid.NewGuid(),
        //                Quantity = 5,
        //            }
        //        },
        //    Address = new AddressModel()
        //    {
        //        StreetName = "Vatytina",
        //        HouseNumber = "58",
        //        ApartmentNumber = "101",
        //    },
        //    UserName = "Volodya"
        //};

        //var delivery = deliveryService.CheckoutBusket(dto);
        //}
    }
}