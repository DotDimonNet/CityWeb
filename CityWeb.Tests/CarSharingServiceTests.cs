using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Infrastructure.Service.Transport;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    class CarSharingServiceTests
    {
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }

        [Test]
        public async Task CreateCarSharingTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext);
            var dto = new CreateCarSharingModelDTO()
            {
                Title = "CarSharing Company",
                Description = "Default description of CarSharing company"
            };

            var carSharing = await carSharingService.CreateCarSharing(dto);
            var carSharingFromContext = TestHelper.ApplicationContext.CarSharings.FirstOrDefault(x => x.Title == carSharing.Title);

            Assert.IsNotNull(carSharing);
            Assert.AreEqual(carSharing.Description, carSharingFromContext.Description);
            Assert.AreEqual(carSharing.Title, carSharingFromContext.Title);
        }
    }
}
