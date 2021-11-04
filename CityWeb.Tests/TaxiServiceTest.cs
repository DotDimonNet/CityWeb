using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.DTO.Transport.Taxi;
using CityWeb.Infrastructure.Service.Transport;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class TaxiServiceTest
    {
        //[SetUp]
        //public async Task Setup()
        //{
        //    await TestHelper.SetupDbContext();
        //}

        //public async Task CreateTaxiTest()
        //{
        //    var taxiService = new TaxiService(TestHelper.ApplicationContext);
        //    var dto = new CreateTaxiModelDTO()
        //    {
        //        Title = "Taxi Company",
        //        Description = "Default description of Taxi company"
        //    };

        //    var taxi = await taxiService.CreateTaxi(dto);
        //    var taxiFromContext = TestHelper.ApplicationContext.Taxi.FirstOrDefault(x => x.Title == taxi.Title);

        //    Assert.IsNotNull(taxi);
        //    Assert.AreEqual(taxi.Description, taxiFromContext.Description);
        //    Assert.AreEqual(taxi.Title, taxiFromContext.Title);
        //}

        //[Test]
        //public void CreateTaxiAlreadyExistTest()
        //{
        //    var taxiService = new TaxiService(TestHelper.ApplicationContext);
        //    var dto = new CreateTaxiModelDTO()
        //    {
        //        Title = "Taxi1",
        //        Description = "Default description of Taxi company"
        //    };

        //    var exept = Assert.ThrowsAsync<Exception>(async () => await taxiService.CreateTaxi(dto));
        //    Assert.AreEqual(exept.Message, "Taxi already exist, cant create one more with same title!");
        //}

        //[Test]
        //public async Task DeleteTaxiTest()
        //{
        //    var taxiService = new TaxiService(TestHelper.ApplicationContext);
        //    var dto = new DeleteTaxiModelDTO()
        //    {
        //        Title = "Taxi1"
        //    };

        //    var taxi = await taxiService.DeleteTaxi(dto);
        //    var taxiFromContext = TestHelper.ApplicationContext.Taxi.FirstOrDefault(x => x.Title == dto.Title);

        //    Assert.IsTrue(taxi);
        //    Assert.IsNull(taxiFromContext);
        //}

        //[Test]
        //public void DeleteTaxiDoesNotExistTest()
        //{
        //    var taxiService = new TaxiService(TestHelper.ApplicationContext);
        //    var dto = new DeleteTaxiModelDTO()
        //    {
        //        Title = " "
        //    };

        //    var exept = Assert.ThrowsAsync<Exception>(async () => await taxiService.DeleteTaxi(dto));
        //    Assert.AreEqual(exept.Message, "Taxi does not exist");
        //}

        //[Test]
        //public async Task UpdateTaxiTest()
        //{
        //    var taxiService = new TaxiService(TestHelper.ApplicationContext);
        //    var dto = new UpdateTaxiModelDTO()
        //    {
        //        Title = "Taxi1",
        //        Description = "new car sharing description",
        //    };

        //    var taxi = await taxiService.UpdateTaxi(dto);
        //    var taxiFromContext = TestHelper.ApplicationContext.Taxi.FirstOrDefault(x => x.Title == taxi.Title);

        //    Assert.AreEqual(taxi.Title, taxiFromContext.Title);
        //    Assert.AreEqual(taxi.Description, taxiFromContext.Description);
        //}

        //[Test]
        //public void UpdateTaxiDoesNotExistTest()
        //{
        //    var taxiService = new TaxiService(TestHelper.ApplicationContext);
        //    var dto = new UpdateTaxiModelDTO()
        //    {
        //        Title = " ",
        //        Description = "new car sharing description",
        //    };

        //    var exept = Assert.ThrowsAsync<Exception>(async () => await taxiService.UpdateTaxi(dto));
        //    Assert.AreEqual(exept.Message, "Taxi does not exist");
        //}

        //[Test]
        //public async Task AddTaxiCarTest()
        //{
        //    var taxiCarService = new TaxiService(TestHelper.ApplicationContext);
        //    var carDTO = new AddTaxiCarDTO()
        //    {
        //        VINCode = "AAD48964500",
        //        TaxiTitle = "Taxi1",
        //        Color = "red",
        //        Mark = "Honda",
        //        Number = "AB 5555 CC",
        //        Seats = 2,
        //        Type = Domain.Enums.TransportType.TaxiBusiness
        //    };

        //    var taxiCar = await taxiCarService.AddTaxiCar(carDTO);
        //    var taxiCarFromContext = TestHelper.ApplicationContext.TaxiCar.FirstOrDefault(x => x.VINCode == taxiCar.VINCode);
        //    var dublicateCount = TestHelper.ApplicationContext.TaxiCar.Count(x => x.VINCode == taxiCar.VINCode);

        //    Assert.IsNotNull(taxiCar);
        //    Assert.Less(dublicateCount, 2);
        //    Assert.AreEqual(taxiCar.VINCode, taxiCarFromContext.VINCode);
        //}

        //[Test]
        //public void AddTaxiCarAlreadyExistTest()
        //{
        //    var taxiCarService = new TaxiService(TestHelper.ApplicationContext);
        //    var carDTO = new AddTaxiCarDTO()
        //    {
        //        VINCode = "TAG48964500",
        //        TaxiTitle = "Taxi1",
        //        Color = "red",
        //        Mark = "Honda",
        //        Number = "AB 5555 CC",
        //        Seats = 2,
        //        Type = Domain.Enums.TransportType.TaxiBusiness
        //    };

        //    var exept = Assert.ThrowsAsync<Exception>(async () => await taxiCarService.AddTaxiCar(carDTO));
        //    Assert.AreEqual(exept.Message, "Car already exist, cant create with same VINCode!");
        //}

        //[Test]
        //public void AddTaxiCarTaxiNotExistTest()
        //{
        //    var taxiCarService = new TaxiService(TestHelper.ApplicationContext);
        //    var carDTO = new AddTaxiCarDTO()
        //    {
        //        VINCode = "aAG4896451C",
        //        TaxiTitle = " ",
        //        Color = "red",
        //        Mark = "Honda",
        //        Number = "AB 5555 CC",
        //        Seats = 2,
        //        Type = Domain.Enums.TransportType.TaxiBusiness
        //    };

        //    var exept = Assert.ThrowsAsync<Exception>(async () => await taxiCarService.AddTaxiCar(carDTO));
        //    Assert.AreEqual(exept.Message, "Taxi does not exist!");
        //}

        //[Test]
        //public async Task DeleteTaxiCarTest()
        //{
        //    var taxiCarService = new TaxiService(TestHelper.ApplicationContext);
        //    var carDTO = new DeleteTaxiCarDTO()
        //    {
        //        VINCode = "TAG48964500",
        //    };

        //    var taxiCar = await taxiCarService.DeleteTaxiCar(carDTO);
        //    var taxiCarFromContext = TestHelper.ApplicationContext.TaxiCar.FirstOrDefault(x => x.VINCode == carDTO.VINCode);

        //    Assert.IsNull(taxiCarFromContext);
        //    Assert.IsTrue(taxiCar);
        //}

        //[Test]
        //public void DeleteTaxiCarDoesNotExistTest()
        //{
        //    var taxiCarService = new TaxiService(TestHelper.ApplicationContext);
        //    var carDTO = new DeleteTaxiCarDTO()
        //    {
        //        VINCode = " ",
        //    };

        //    var exept = Assert.ThrowsAsync<Exception>(async () => await taxiCarService.DeleteTaxiCar(carDTO));
        //    Assert.AreEqual(exept.Message, "Car does not exist");
        //}

        //[Test]
        //public async Task UpdateTaxiCarTest()
        //{
        //    var taxiCarService = new TaxiService(TestHelper.ApplicationContext);
        //    var carDTO = new UpdateTaxiCarDTO()
        //    {
        //        VINCode = "TAG48964500",
        //        Color = "white",
        //        Mark = "Honda",
        //        Number = "AB 5855 CC",
        //        Seats = 1,
        //        Type = Domain.Enums.TransportType.TaxiBusiness
        //    };

        //    var taxiCar = await taxiCarService.UpdateTaxiCar(carDTO);
        //    var taxiCarFromContext = TestHelper.ApplicationContext.TaxiCar.FirstOrDefault(x => x.VINCode == carDTO.VINCode);

        //    Assert.IsNotNull(taxiCar);
        //    Assert.IsNotNull(taxiCarFromContext);

        //    Assert.AreEqual(taxiCarFromContext.VINCode, taxiCar.VINCode);
        //    Assert.AreEqual(taxiCarFromContext.Color, taxiCar.Color);
        //    Assert.AreEqual(taxiCarFromContext.Mark, taxiCar.Mark);
        //    Assert.AreEqual(taxiCarFromContext.Number, taxiCar.Number);
        //    Assert.AreEqual(taxiCarFromContext.Seats, taxiCar.Seats);
        //    Assert.AreEqual(taxiCarFromContext.Type, taxiCar.Type);
        //}

        //[Test]
        //public void UpdateTaxiCarDoesNotExistTest()
        //{
        //    var taxiCarService = new TaxiService(TestHelper.ApplicationContext);
        //    var carDTO = new UpdateTaxiCarDTO()
        //    {
        //        VINCode = " ",
        //        Color = "white",
        //        Mark = "Honda",
        //        Number = "AB 5855 CC",
        //        Seats = 1,
        //        Type = Domain.Enums.TransportType.TaxiBusiness
        //    };

        //    var exept = Assert.ThrowsAsync<Exception>(async () => await taxiCarService.UpdateTaxiCar(carDTO));
        //    Assert.AreEqual(exept.Message, "Car does not exist");
        //}

        //[Test]
        //public void SetupTaxiBuilderResultTest()
        //{
        //    var taxiCarService = new TaxiService(TestHelper.ApplicationContext);
        //    var builder = taxiCarService.SetupTaxiBuilderResult();

        //    Assert.IsNotNull(builder);
        //}
    }
}
