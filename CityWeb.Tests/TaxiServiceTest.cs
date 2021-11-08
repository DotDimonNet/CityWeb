using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Service.Transport;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class TaxiServiceTest
    {
        private Mock<ILogger<TaxiService>> _loggerMock;
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _loggerMock = TestHelper.SetupTestLogger<TaxiService>();
        }

        [Test]
        public async Task CreateTaxiTest()
        {
            TaxiService taxiService = new TaxiService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            CreateTaxiModelDTO dto = new CreateTaxiModelDTO()
            {
                Title = "Taxi Company",
                Description = "Default description of Taxi company"
            };

            TaxiModelDTO taxi = await taxiService.CreateTaxi(dto);
            TaxiModel taxiFromContext = TestHelper.ApplicationContext.Taxi.FirstOrDefault(x => x.Title == taxi.Title);

            Assert.IsNotNull(taxi);
            Assert.AreEqual(taxi.Description, taxiFromContext.Description);
            Assert.AreEqual(taxi.Title, taxiFromContext.Title);
        }

        [Test]
        public async Task DeleteTaxiTest()
        {
            TaxiService taxiService = new TaxiService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            DeleteTaxiModelDTO dto = new DeleteTaxiModelDTO()
            {
                Id = TestHelper.ApplicationContext.Taxi.FirstOrDefault().Id
            };

            bool taxi = await taxiService.DeleteTaxi(dto);
            TaxiModel taxiFromContext = TestHelper.ApplicationContext.Taxi.FirstOrDefault(x => x.Id == dto.Id);

            Assert.IsTrue(taxi);
            Assert.IsNull(taxiFromContext);
        }

        [Test]
        public async Task UpdateTaxiTest()
        {
            TaxiService taxiService = new TaxiService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            UpdateTaxiModelDTO dto = new UpdateTaxiModelDTO()
            {
                Id = TestHelper.ApplicationContext.Taxi.FirstOrDefault().Id,
                Title = "Taxi1",
                Description = "new car sharing description",
            };

            TaxiModelDTO taxi = await taxiService.UpdateTaxi(dto);
            TaxiModel taxiFromContext = TestHelper.ApplicationContext.Taxi.FirstOrDefault(x => x.Id == dto.Id);

            Assert.AreEqual(taxi.Title, taxiFromContext.Title);
            Assert.AreEqual(taxi.Description, taxiFromContext.Description);
        }

        [Test]
        public async Task AddTaxiCarTest()
        {
            TaxiService taxiCarService = new TaxiService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            AddTaxiCarDTO carDTO = new AddTaxiCarDTO()
            {
                TaxiId = TestHelper.ApplicationContext.Taxi.FirstOrDefault().Id,
                Color = "red",
                Mark = "Honda",
                Number = "AB 5555 CC",
                Seats = 2,
                Type = "Econom"
            };

            TaxiCarModelDTO taxiCar = await taxiCarService.AddTaxiCar(carDTO);
            TaxiCarModel taxiCarFromContext = TestHelper.ApplicationContext.TaxiCar.FirstOrDefault(x => x.Id == taxiCar.Id);
            int dublicateCount = TestHelper.ApplicationContext.TaxiCar.Count(x => x.Id == carDTO.TaxiId);

            Assert.IsNotNull(taxiCar);
            Assert.Less(dublicateCount, 2);
            Assert.AreEqual(taxiCar.Id, taxiCarFromContext.Id);
        }

        [Test]
        public async Task DeleteTaxiCarTest()
        {
            TaxiService taxiCarService = new TaxiService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            DeleteTaxiCarDTO carDTO = new DeleteTaxiCarDTO()
            {
                Id = TestHelper.ApplicationContext.TaxiCar.FirstOrDefault().Id
            };

            bool taxiCar = await taxiCarService.DeleteTaxiCar(carDTO);
            TaxiCarModel taxiCarFromContext = TestHelper.ApplicationContext.TaxiCar.FirstOrDefault(x => x.Id == carDTO.Id);

            Assert.IsNull(taxiCarFromContext);
            Assert.IsTrue(taxiCar);
        }

        [Test]
        public async Task UpdateTaxiCarTest()
        {
            TaxiService taxiCarService = new TaxiService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            UpdateTaxiCarDTO carDTO = new UpdateTaxiCarDTO()
            {
                Id = TestHelper.ApplicationContext.TaxiCar.FirstOrDefault().Id,
                Color = "white",
                Mark = "Honda",
                Number = "AB 5855 CC",
                Seats = 1,
                Type = "Business"
            };

            TaxiCarModelDTO taxiCar = await taxiCarService.UpdateTaxiCar(carDTO);
            TaxiCarModel taxiCarFromContext = TestHelper.ApplicationContext.TaxiCar.FirstOrDefault(x => x.Id == carDTO.Id);

            Assert.IsNotNull(taxiCar);
            Assert.IsNotNull(taxiCarFromContext);

            Assert.AreEqual(taxiCarFromContext.Id, taxiCar.Id);
            Assert.AreEqual(taxiCarFromContext.Color, taxiCar.Color);
            Assert.AreEqual(taxiCarFromContext.Mark, taxiCar.Mark);
            Assert.AreEqual(taxiCarFromContext.Number, taxiCar.Number);
            Assert.AreEqual(taxiCarFromContext.Seats, taxiCar.Seats);
            Assert.AreEqual(taxiCarFromContext.Type.ToString(), taxiCar.Type);
        }
    }
}
