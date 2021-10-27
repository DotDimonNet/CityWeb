using CityWeb.Domain.DTO;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Service;
using NUnit.Framework;
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
        public async Task CreateMenuTest()
        {
            var deliveryService1 = new DeliveryService(TestHelper.ApplicationContext);
            var deliveryDTO = new CreateDeliveryModelDTO()
            {
                Title = "Delivery Company",
                Description = "Default description"
            };

            var delivery = await deliveryService1.CreateDeliveryCompany(deliveryDTO);
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto2 = new ProductModelDTO()
            {
                Title = "Delivery Company",
                ProductName = "pizza",
                ProductType = ProductType.AlcoholicDrinks,
                ProductImage = "img",
                Value = 200.00,
                Tax = 10.00,
                VAT = 10.00,
            };

            var product = await deliveryService.CreateMenu(dto2);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == product.ProductName);

            Assert.IsNotNull(product);
            Assert.AreEqual(product.ProductName, productFromContext.ProductName);
            Assert.AreEqual(product.ProductType.Name, productFromContext.ProductType.Name);
            Assert.AreEqual(product.ProductImage, productFromContext.ProductImage);
            Assert.AreEqual(product.VAT, productFromContext.ProductPrice.VAT);
            Assert.AreEqual(product.Tax, productFromContext.ProductPrice.Tax);
            Assert.AreEqual(product.Value, productFromContext.ProductPrice.Value);
            
        }
    }
}