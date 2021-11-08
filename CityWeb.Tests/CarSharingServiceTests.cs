using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Service.Transport;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    class CarSharingServiceTests
    {
        private Mock<ILogger<CarSharingService>> _loggerMock;
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _loggerMock = TestHelper.SetupTestLogger<CarSharingService>();
        }

        [Test]
        public async Task CreateCarSharingTest()
        {
            CarSharingService carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            CreateCarSharingModelDTO dto = new CreateCarSharingModelDTO()
            {
                Title = "CarSharing Company",
                Description = "Default description of CarSharing company",
                Location = new AddressModelDTO()
                {
                    StreetName = "Yangelya",
                    HouseNumber = "25",
                    ApartmentNumber = "1"
                }
            };

            CarSharingModelDTO carSharing = await carSharingService.CreateCarSharing(dto);
            CarSharingModel carSharingFromContext = TestHelper.ApplicationContext.CarSharings.FirstOrDefault(x => x.Title == carSharing.Title);

            Assert.IsNotNull(carSharing);
            Assert.AreEqual(carSharing.Description, carSharingFromContext.Description);
            Assert.AreEqual(carSharing.Title, carSharingFromContext.Title);
        }

        [Test]
        public async Task DeleteCarSharingTest()
        {
            CarSharingService carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            DeleteCarSharingModelDTO dto = new DeleteCarSharingModelDTO()
            {
                Id = TestHelper.ApplicationContext.CarSharings.FirstOrDefault().Id
            };

            bool carSharing = await carSharingService.DeleteCarSharing(dto);
            CarSharingModel carSharingFromContext = TestHelper.ApplicationContext.CarSharings.FirstOrDefault(x => x.Id == dto.Id);

            Assert.IsTrue(carSharing);
            Assert.IsNull(carSharingFromContext);
        }

        [Test]
        public async Task UpdateCarSharingTest()
        {
            CarSharingService carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            UpdateCarSharingModelDTO dto = new UpdateCarSharingModelDTO()
            {
                Id = TestHelper.ApplicationContext.CarSharings.FirstOrDefault().Id,
                Title = "CarSharing1",
                Description = "new car sharing description",
                Location = new AddressModelDTO()
                {
                    StreetName = "Yangelya",
                    HouseNumber = "25",
                    ApartmentNumber = "1"
                }
            };

            CarSharingModelDTO carSharing = await carSharingService.UpdateCarSharing(dto);
            CarSharingModel carSharingFromContext = TestHelper.ApplicationContext.CarSharings.FirstOrDefault(x => x.Id == dto.Id);

            Assert.AreEqual(carSharing.Title, carSharingFromContext.Title);
            Assert.AreEqual(carSharing.Description, carSharingFromContext.Description);
        }

        [Test]
        public async Task AddRentCarTest()
        {
            CarSharingService rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            AddRentCarDTO carDTO = new AddRentCarDTO()
            {
                CarSharingId = TestHelper.ApplicationContext.CarSharings.FirstOrDefault().Id,
                Color = "red",
                Mark = "Honda",
                Number = "AB 5555 CC",
                Seats = 2,
                Type = "Business"
            };

            RentCarModelDTO rentCar = await rentCarService.AddRentCar(carDTO);
            RentCarModel rentCarFromContext = TestHelper.ApplicationContext.RentCars.FirstOrDefault(x => x.Id == rentCar.Id);
            int dublicateCount = TestHelper.ApplicationContext.RentCars.Count(x => x.Id == carDTO.CarSharingId);

            Assert.IsNotNull(rentCar);
            Assert.IsNotNull(rentCarFromContext);
            Assert.Less(dublicateCount, 2);
            Assert.AreEqual(rentCar.Id, rentCarFromContext.Id);
        }

        [Test]
        public async Task DeleteRentCarTest()
        {
            CarSharingService rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            DeleteRentCarDTO carDTO = new DeleteRentCarDTO()
            {
                Id = TestHelper.ApplicationContext.RentCars.FirstOrDefault().Id
            };

            bool rentCar = await rentCarService.DeleteRentCar(carDTO);
            RentCarModel rentCarFromContext = TestHelper.ApplicationContext.RentCars.FirstOrDefault(x => x.Id == carDTO.Id);

            Assert.IsNull(rentCarFromContext);
            Assert.IsTrue(rentCar);
        }

        [Test]
        public async Task UpdateRentCarTest()
        {
            CarSharingService rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            UpdateRentCarDTO carDTO = new UpdateRentCarDTO()
            {
                Id = TestHelper.ApplicationContext.RentCars.FirstOrDefault().Id,
                Color = "blue",
                Mark = "Honda",
                Number = "AB 5855 CC",
                Seats = 1,
                Type = "Econom"
            };

            RentCarModelDTO rentCar = await rentCarService.UpdateRentCar(carDTO);
            RentCarModel rentCarFromContext = TestHelper.ApplicationContext.RentCars.FirstOrDefault(x => x.Id == carDTO.Id);

            Assert.IsNotNull(rentCar);
            Assert.IsNotNull(rentCarFromContext);

            Assert.AreEqual(rentCarFromContext.Id, rentCar.Id);
            Assert.AreEqual(rentCarFromContext.Color, rentCar.Color);
            Assert.AreEqual(rentCarFromContext.Mark, rentCar.Mark);
            Assert.AreEqual(rentCarFromContext.Number, rentCar.Number);
            Assert.AreEqual(rentCarFromContext.Seats, rentCar.Seats);
            Assert.AreEqual(rentCarFromContext.Type.ToString(), rentCar.Type);
        }

        [Test]
        public void SetupCarSharingBuilderResultTest()
        {
            CarSharingService rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            CarSharingBuilderResult builder = rentCarService.SetupCarSharingBuilderResult();

            Assert.IsNotNull(builder);
        }

        [Test]
        public async Task GetAllCarsOfCarSharingTest()
        {
            CarSharingService rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            CarSharingBuilderResult builder = new CarSharingBuilderResult();
            IEnumerable<RentCarModelDTO> stepOneResult = await rentCarService.GetAllCarsOfCarSharing(builder, TestHelper.ApplicationContext.CarSharings.FirstOrDefault().Id);
            List<RentCarModel> stepOneResultFromContext = await TestHelper.ApplicationContext.RentCars.Where(x => x.CarSharing.Id == builder.CarSharingId).ToListAsync();

            foreach (var item in stepOneResult.ToList())
            {
                //Assert.Contains(item, stepOneResultFromContext.Select(x => TestHelper.TestMapper.Map<RentCarModel, RentCarModelDTO>(x)).ToList());
                Assert.Contains(item.Color, stepOneResultFromContext.Select(x => x.Color).ToList());
                Assert.Contains(item.Mark, stepOneResultFromContext.Select(x => x.Mark).ToList());
                Assert.Contains(item.Number, stepOneResultFromContext.Select(x => x.Number).ToList());
                Assert.Contains(item.Seats, stepOneResultFromContext.Select(x => x.Seats).ToList());
                Assert.Contains(item.Id, stepOneResultFromContext.Select(x => x.Id).ToList());
            }
        }

        [Test]
        public async Task ChooseCarTest()
        {
            CarSharingService carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            CarSharingBuilderResult builder = new CarSharingBuilderResult();
            await carSharingService.GetAllCarsOfCarSharing(builder, TestHelper.ApplicationContext.CarSharings.FirstOrDefault().Id);
            Guid carId = TestHelper.ApplicationContext.RentCars.FirstOrDefault().Id;
            IEnumerable<PeriodModelDTO> stepTwoResult = await carSharingService.GetCarResersedPeriods(builder, carId);
            ICollection<PeriodModel> stepTwoResultFromComtext = TestHelper.ApplicationContext.RentCars.FirstOrDefault().RentPeriod;

            foreach (var item in stepTwoResult)
            {
                //Assert.Contains(item, stepTwoResultFromComtext.Select(x => TestHelper.TestMapper.Map<PeriodModel, PeriodModelDTO>(x)).ToList());
                Assert.Contains(item.StartTime, stepTwoResultFromComtext.Select(x => x.StartTime).ToList());
                Assert.Contains(item.EndTime, stepTwoResultFromComtext.Select(x => x.EndTime).ToList());
            }
        }

        [Test]
        public async Task CheckRentTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            var builder = new CarSharingBuilderResult();
            await carSharingService.GetAllCarsOfCarSharing(builder, Guid.NewGuid());
            await carSharingService.GetCarResersedPeriods(builder, Guid.NewGuid());

            var period = new PeriodModelDTO()
            {
                StartTime = DateTime.Now.AddDays(5),
                EndTime = DateTime.Now.AddDays(7)
            };
            var builder2 = builder;
            builder2.RentPeriod = new PeriodModelDTO()
            {
                StartTime = period.StartTime,
                EndTime = period.EndTime
            };
            builder2.RentPeriod.EndTime = period.EndTime;
            var car = await TestHelper.ApplicationContext.RentCars.FirstOrDefaultAsync(x => x.Id == Guid.NewGuid());
            builder2.Price = (period.EndTime.Day - period.StartTime.Day) * car.Price.Total;

            var result = await carSharingService.CheckRent(builder, period);

            Assert.IsTrue(result);
            Assert.AreEqual(builder, builder2);
        }

        [Test]
        public async Task GetAllCarSharingsTest()
        {
            CarSharingService carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            IEnumerable<CarSharingModelDTO> carSharings = await carSharingService.GetAllCarSharings();
            var carSharingsFromContext = TestHelper.ApplicationContext.CarSharings.ToList();

            foreach (var item in carSharings)
            {
                Assert.Contains(item.Title, carSharingsFromContext.Select(x => x.Title).ToList());
            }
        }

        [Test]
        public async Task GetAllRentCarsTest()
        {
            CarSharingService carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper, _loggerMock.Object);
            IEnumerable<RentCarModelDTO> rentCars = await carSharingService.GetAllRentCars();
            List<RentCarModelDTO> rentCarsFromContext = await TestHelper.ApplicationContext.RentCars.Select(x => TestHelper.TestMapper.Map<RentCarModel, RentCarModelDTO>(x)).ToListAsync();

            foreach (var item in rentCars)
            {
                Assert.Contains(item.Id, rentCarsFromContext.Select(x => x.Id).ToList());
            }
        }
    }
}
