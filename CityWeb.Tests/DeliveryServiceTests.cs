using CityWeb.Domain.DTO;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Service;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class DeliveryServiceTests
    {
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }

        [Test]
        public async Task CreateDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new CreateDeliveryModelDTO()
            {
                Title = "Delivery Company",
                Description = "Default description"
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
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new UpdateDeliveryModelDTO()
            {
                Title = "DeliveryCompany2",
                Description = "Super quick",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Value = 10.00,
                Tax = 0.00,
                VAT = 2.00,
            };
            var delivery = await deliveryService.UpdateDeliveryCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == dto.Title);

            Assert.IsNotNull(delivery);
            Assert.AreEqual(delivery.Description, deliveryFromContext.Description);
            Assert.AreEqual(delivery.StartTime, deliveryFromContext.WorkSchedule.StartTime);
            Assert.AreEqual(delivery.EndTime, deliveryFromContext.WorkSchedule.EndTime);
            Assert.AreEqual(delivery.Value, deliveryFromContext.DeliveryPrice.Value);
        }

        [Test]
        public async Task CreateMenuTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductModelDTO()
            {
                Title = "DeliveryCompany2",
                ProductName = "Product",
                ProductType = ProductType.AlcoholicDrinks,
                ProductImage = "img",
                Value = 200.00,
                Tax = 10.00,
                VAT = 10.00,
            };

            var product = await deliveryService.CreateMenu(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == product.ProductName);

            Assert.IsNotNull(product);
            Assert.AreEqual(product.ProductName, productFromContext.ProductName);
            Assert.AreEqual(product.ProductType.Name, productFromContext.ProductType.Name);
            Assert.AreEqual(product.ProductImage, productFromContext.ProductImage);
            Assert.AreEqual(product.VAT, productFromContext.ProductPrice.VAT);
            Assert.AreEqual(product.Tax, productFromContext.ProductPrice.Tax);
            Assert.AreEqual(product.Value, productFromContext.ProductPrice.Value);
        }

        [Test]
        public async Task UpdateProductTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductModelDTO()
            {
                Title = "DeliveryCompany1",
                ProductName = "Product1",
                Value = 300.00,
            };

            var product = await deliveryService.UpdateProduct(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == product.ProductName);
            Assert.IsNotNull(product);
            Assert.AreEqual(product.Value, productFromContext.ProductPrice.Value);
        }

        [Test]
        public async Task DeleteDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeleteCompanyDTO()
            {
                Title = "DeliveryCompany6"
            };

            await deliveryService.DeleteDeliveryCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == dto.Title);
            Assert.IsNull(deliveryFromContext);    
        }

        [Test]
        public async Task DeleteProductTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeleteProductDTO()
            {
                Title = "DeliveryCompany6",
                ProductName = "Product6",
            };

            await deliveryService.DeleteProduct(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == dto.ProductName);
            Assert.IsNull(productFromContext);
        }

        [Test]
        public async Task ShowWorkingCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeliveryCompanySheduleDTO()
            {
                WorkTime = DateTime.Now,
            };

            deliveryService.ShowWorkingCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.Where(x => x.WorkSchedule.StartTime < dto.WorkTime && x.WorkSchedule.EndTime > dto.WorkTime).Count();
            Assert.IsTrue(deliveryFromContext == 10);
        }
    }
}