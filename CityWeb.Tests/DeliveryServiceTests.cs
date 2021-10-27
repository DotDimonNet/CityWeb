using CityWeb.Domain.DTO;
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
            var deliveryService = new DeliveryServise(TestHelper.ApplicationContext); 
            var dto = new DeliveryModelDTO()
            {
                Title = "Delivery Company",
                Description = "Default description"
            };

            var delivery = await deliveryService.CreateDeliveryCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Id == delivery.Id);

            Assert.IsNotNull(delivery);
            Assert.AreEqual(delivery.Description, deliveryFromContext.Description);
            Assert.AreEqual(delivery.Title, deliveryFromContext.Title);
        }
    }
}