using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Extentions;
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
        public async Task DeleteCarSharingTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext);
            var dto = new DeleteCarSharingModelDTO()
            {
                Title = "CarSharing1"
            };

            var carSharing = await carSharingService.DeleteCarSharing(dto);
            var carSharingFromContext = TestHelper.ApplicationContext.CarSharings.FirstOrDefault(x => x.Title == dto.Title);

            Assert.IsTrue(carSharing);
            Assert.IsNull(carSharingFromContext);
        }

        [Test]
        public async Task UpdateCarSharingTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext);
            var dto = new UpdateCarSharingModelDTO()
            {
                Title = "CarSharing1",
                Description = "new car sharing description",
            };

            var carSharing = await carSharingService.UpdateCarSharing(dto);
            var carSharingFromContext = TestHelper.ApplicationContext.CarSharings.FirstOrDefault(x => x.Title == carSharing.Title);

            Assert.AreEqual(carSharing.Title, carSharingFromContext.Title);
            Assert.AreEqual(carSharing.Description, carSharingFromContext.Description);
        }

        [Test]
        public async Task AddRentCarTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext);
            var carDTO = new AddRentCarDTO()
            {
                VINCode = "GAG4896451C",
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

        [Test]
        public async Task DeleteRentCatTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext);
            var carDTO = new DeleteRentCarDTO()
            {
                VINCode = "BAG48964501",
            };

            var rentCar = await rentCarService.DeleteRentCar(carDTO);
            var rentCarFromContext = TestHelper.ApplicationContext.RentCars.FirstOrDefault(x => x.VINCode == carDTO.VINCode);

            Assert.IsNull(rentCarFromContext);
            Assert.IsTrue(rentCar);
        }

        [Test]
        public async Task UpdateRentCar()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext);
            var carDTO = new UpdateRentCarDTO()
            {
                VINCode = "BAG48964500",
                Color = "white",
                Mark = "Honda",
                Number = "AB 5855 CC",
                Seats = 1,
                Type = Domain.Enums.TransportType.RentCar
            };

            var rentCar = await rentCarService.UpdateRentCar(carDTO);
            var rentCarFromContext = TestHelper.ApplicationContext.RentCars.FirstOrDefault(x => x.VINCode == carDTO.VINCode);

            Assert.IsNotNull(rentCar);
            Assert.IsNotNull(rentCarFromContext);

            Assert.AreEqual(rentCarFromContext.VINCode, rentCar.VINCode);
            Assert.AreEqual(rentCarFromContext.Color, rentCar.Color);
            Assert.AreEqual(rentCarFromContext.Mark, rentCar.Mark);
            Assert.AreEqual(rentCarFromContext.Number, rentCar.Number);
            Assert.AreEqual(rentCarFromContext.Seats, rentCar.Seats);
            Assert.AreEqual(rentCarFromContext.Type, rentCar.Type);
        }

        [Test]
        public void SetupCarSharingBuilderResultTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext);
            var builder = rentCarService.SetupCarSharingBuilderResult();

            Assert.IsNotNull(builder);
        }

        [Test]
        public async Task StepOneTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext);
            var builder = new CarSharingBuilderResult();
            var stepOneResult = await rentCarService.StepOne(builder, "CarSharing1");
            var stepOneResultFromContext = TestHelper.ApplicationContext.RentCars.Where(x => x.CarSharing.Title == builder.CarSharingTitle);

            foreach (var item in stepOneResult.ToList())
            {
                //Assert.Contains(item, stepOneResultFromContext.Select(x => x.ToRentCarsModelDTO()).ToList());
                Assert.Contains(item.Color, stepOneResultFromContext.Select(x => x.Color).ToList());
                Assert.Contains(item.Mark, stepOneResultFromContext.Select(x => x.Mark).ToList());
                Assert.Contains(item.Number, stepOneResultFromContext.Select(x => x.Number).ToList());
                Assert.Contains(item.Seats, stepOneResultFromContext.Select(x => x.Seats).ToList());
                Assert.Contains(item.Type, stepOneResultFromContext.Select(x => x.Type).ToList());
                Assert.Contains(item.VINCode, stepOneResultFromContext.Select(x => x.VINCode).ToList());
            }


            /*var resultList = stepOneResult.ToList();
            var resultListFromContext = stepOneResultFromContext.Select(x => x.ToRentCarsModelDTO()).ToList();
            /*
            for (int i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(resultList[i], resultListFromContext[i]);
            }*/
        }

        [Test]
        public async Task StepTwoTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext);
            var builder = new CarSharingBuilderResult();
            await rentCarService.StepOne(builder, "CarSharing1");
            var stepTwoResult = await rentCarService.StepTwo(builder, "BAG48964500");
            var stepTwoResultFromComtext = TestHelper.ApplicationContext.RentCars.FirstOrDefault(x => x.VINCode == "BAG48964500");

            Assert.AreEqual(stepTwoResult.VINCode, stepTwoResultFromComtext.VINCode);
        }

        [Test]
        public async Task StepThreeTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext);
            var builder = new CarSharingBuilderResult();
            await rentCarService.StepOne(builder, "CarSharing1");
            await rentCarService.StepTwo(builder, "BAG48964500");
         
            var period = new PeriodModel()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(2)
            };
            var builder2 = builder;
            builder2.RentPeriod = period;
            builder2.Price = new PriceModel()
            {
                Value = (period.EndTime.Day - period.StartTime.Day) * builder2.Car.Price.Total
            };

            builder = await rentCarService.StepThree(builder, period);

            Assert.AreEqual(builder, builder2);
        }

    }
}
