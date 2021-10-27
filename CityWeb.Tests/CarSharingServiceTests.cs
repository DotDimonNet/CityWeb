using CityWeb.Domain.DTO.Transport.Car;
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

        [Test]
        public async Task AddRentCarTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext);
            var carDTO = new AddRentCarDTO()
            {
                VINCode = "VAG4896451",
                CarSharingTitle = "CarSharing1",
                Color = "red",
                Mark = "Honda",
                Number = "AB 5555 CC",
                Seats = 2,
                Type = Domain.Enums.TransportType.RentCar
            };

            var rentCar = await rentCarService.AddRentCar(carDTO);
            var rentCarFromContext = TestHelper.ApplicationContext.RentCars.FirstOrDefault(x => x.VINCode == rentCar.VINCode);
            var dublicateCount = TestHelper.ApplicationContext.RentCars.Count(x => x.VINCode == rentCar.VINCode);

            Assert.IsNotNull(rentCar);
            Assert.Less(dublicateCount, 2);
            Assert.AreEqual(rentCar.VINCode, rentCarFromContext.VINCode);
        }
        
    }
}
