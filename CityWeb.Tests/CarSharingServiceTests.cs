using AutoMapper;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.CarSharing;
using CityWeb.Domain.Entities;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastructure.Service.Transport;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
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
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new CreateCarSharingModelDTO()
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

            var carSharing = await carSharingService.CreateCarSharing(dto);
            var carSharingFromContext = TestHelper.ApplicationContext.CarSharings.FirstOrDefault(x => x.Title == carSharing.Title);

            Assert.IsNotNull(carSharing);
            Assert.AreEqual(carSharing.Description, carSharingFromContext.Description);
            Assert.AreEqual(carSharing.Title, carSharingFromContext.Title);
        }

        [Test]
        public void CreateCarSharingAlreadyExistTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new CreateCarSharingModelDTO()
            {
                Title = "CarSharing1",
                Description = "Default description of CarSharing company"
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await carSharingService.CreateCarSharing(dto));
            Assert.AreEqual(exept.Message, "CarSharing already exist, cant create one more with same title!");
        }

        [Test]
        public async Task DeleteCarSharingTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
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
        public void DeleteCarSharingDoesNotExistTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new DeleteCarSharingModelDTO()
            {
                Title = " "
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await carSharingService.DeleteCarSharing(dto));
            Assert.AreEqual(exept.Message, "CarSharing does not exist");
        }

        [Test]
        public async Task UpdateCarSharingTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new UpdateCarSharingModelDTO()
            {
                Title = "CarSharing1",
                Description = "new car sharing description",
                Location = new AddressModelDTO()
                {
                    StreetName = "Yangelya",
                    HouseNumber = "25",
                    ApartmentNumber = "1"
                }
            };

            var carSharing = await carSharingService.UpdateCarSharing(dto);
            var carSharingFromContext = TestHelper.ApplicationContext.CarSharings.FirstOrDefault(x => x.Title == carSharing.Title);

            Assert.AreEqual(carSharing.Title, carSharingFromContext.Title);
            Assert.AreEqual(carSharing.Description, carSharingFromContext.Description);
        }

        [Test]
        public void UpdateCarSharingDoesNotExistTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new UpdateCarSharingModelDTO()
            {
                Title = " ",
                Description = "new car sharing description",
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await carSharingService.UpdateCarSharing(dto));
            Assert.AreEqual(exept.Message, "CarSharing does not exist");
        }

        [Test]
        public async Task AddRentCarTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
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
        public void AddRentCarAlreadyExistTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var carDTO = new AddRentCarDTO()
            {
                VINCode = "BAG48964500",
                CarSharingTitle = "CarSharing1",
                Color = "red",
                Mark = "Honda",
                Number = "AB 5555 CC",
                Seats = 2,
                Type = Domain.Enums.TransportType.RentCar
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await rentCarService.AddRentCar(carDTO));
            Assert.AreEqual(exept.Message, "Car already exist, cant create one more with same VIN code!");
        }

        [Test]
        public void AddRentCarCarSharingNotExistTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var carDTO = new AddRentCarDTO()
            {
                VINCode = "GAG4896451C",
                CarSharingTitle = " ",
                Color = "red",
                Mark = "Honda",
                Number = "AB 5555 CC",
                Seats = 2,
                Type = Domain.Enums.TransportType.RentCar
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await rentCarService.AddRentCar(carDTO));
            Assert.AreEqual(exept.Message, "CarSharing does not exist!");
        }

        [Test]
        public async Task DeleteRentCarTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
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
        public void DeleteRentCarDoesNotExistTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var carDTO = new DeleteRentCarDTO()
            {
                VINCode = " ",
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await rentCarService.DeleteRentCar(carDTO));
            Assert.AreEqual(exept.Message, "Car does not exist");
        }

        [Test]
        public async Task UpdateRentCarTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
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
        public void UpdateRentCarDoesNotExistTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var carDTO = new UpdateRentCarDTO()
            {
                VINCode = " ",
                Color = "white",
                Mark = "Honda",
                Number = "AB 5855 CC",
                Seats = 1,
                Type = Domain.Enums.TransportType.RentCar
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await rentCarService.UpdateRentCar(carDTO));
            Assert.AreEqual(exept.Message, "Car does not exist");
        }

        [Test]
        public void SetupCarSharingBuilderResultTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var builder = rentCarService.SetupCarSharingBuilderResult();

            Assert.IsNotNull(builder);
        }

        [Test]
        public async Task GetAllCarsOfCarSharingTest()
        {
            var rentCarService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var builder = new CarSharingBuilderResult();
            var stepOneResult = await rentCarService.GetAllCarsOfCarSharing(builder, "CarSharing1");
            var stepOneResultFromContext = TestHelper.ApplicationContext.RentCars.Where(x => x.CarSharing.Title == builder.CarSharingTitle);

            foreach (var item in stepOneResult.ToList())
            {
                Assert.Contains(item.Color, stepOneResultFromContext.Select(x => x.Color).ToList());
                Assert.Contains(item.Mark, stepOneResultFromContext.Select(x => x.Mark).ToList());
                Assert.Contains(item.Number, stepOneResultFromContext.Select(x => x.Number).ToList());
                Assert.Contains(item.Seats, stepOneResultFromContext.Select(x => x.Seats).ToList());
                Assert.Contains(item.Type, stepOneResultFromContext.Select(x => x.Type).ToList());
                Assert.Contains(item.VINCode, stepOneResultFromContext.Select(x => x.VINCode).ToList());
            }
        }

        [Test]
        public void GetAllCarsOfCarSharingNotExistTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var builder = new CarSharingBuilderResult();
            var exept = Assert.ThrowsAsync<Exception>(async () => await carSharingService.GetAllCarsOfCarSharing(builder, " "));
            Assert.AreEqual(exept.Message, "CarSharing does not exist!");
        }

        [Test]
        public async Task ChooseCarTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var builder = new CarSharingBuilderResult();
            await carSharingService.GetAllCarsOfCarSharing(builder, "CarSharing1");
            var stepTwoResult = await carSharingService.ChooseCar(builder, "BAG48964500");
            var stepTwoResultFromComtext = TestHelper.ApplicationContext.RentCars.FirstOrDefault(x => x.VINCode == "BAG48964500");

            Assert.AreEqual(stepTwoResult.VINCode, stepTwoResultFromComtext.VINCode);
        }

        [Test]
        public async Task ChooseCarDoesNotExistTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var builder = new CarSharingBuilderResult();
            await carSharingService.GetAllCarsOfCarSharing(builder, "CarSharing1");
            var exept = Assert.ThrowsAsync<Exception>(async () => await carSharingService.ChooseCar(builder, " "));
            Assert.AreEqual(exept.Message, "Car does not exist!");
        }

        [Test]
        public async Task CheckRentTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var builder = new CarSharingBuilderResult();
            await carSharingService.GetAllCarsOfCarSharing(builder, "CarSharing1");
            await carSharingService.ChooseCar(builder, "BAG48964500");
         
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
            var car = await TestHelper.ApplicationContext.RentCars.FirstOrDefaultAsync(x => x.VINCode == "BAG48964500");
            builder2.Price = (period.EndTime.Day - period.StartTime.Day) * car.Price.Total;

            var result = await carSharingService.CheckRent(builder, period);

            Assert.IsTrue(result);
            Assert.AreEqual(builder, builder2);
        }

        [Test]
        public async Task CheckRentIsCarFreeTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var builder = new CarSharingBuilderResult();
            await carSharingService.GetAllCarsOfCarSharing(builder, "CarSharing1");
            await carSharingService.ChooseCar(builder, "BAG48964500");
            var period = new PeriodModelDTO()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(2)
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await carSharingService.CheckRent(builder, period));
            Assert.AreEqual(exept.Message, "Car is not free in this period");
        }

        [Test]
        public async Task GetAllCarSharingsTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var carSharings = await carSharingService.GetAllCarSharings();
            var carSharingsFromContext = TestHelper.ApplicationContext.CarSharings.ToList();

            foreach (var item in carSharings)
            {
                Assert.Contains(item.Title, carSharingsFromContext.Select(x => x.Title).ToList());
            }
        }

        [Test]
        public async Task GetAllRentCarsTest()
        {
            var carSharingService = new CarSharingService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var rentCars = await carSharingService.GetAllRentCars();
            var rentCarsFromContext = TestHelper.ApplicationContext.RentCars;

            foreach (var item in rentCars)
            {
                Assert.Contains(item.VINCode, rentCarsFromContext.Select(x => x.VINCode).ToList());
            }
        }
    }
}
