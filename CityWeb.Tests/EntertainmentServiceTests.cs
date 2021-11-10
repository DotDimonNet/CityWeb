using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace CityWeb.Tests
{
    public class EntertainmentServiceTests
    {
        private ILogger<EntertainmentService> _logger;
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _logger = TestHelper.SetupTestLogger<EntertainmentService>();
        }
        [Test]
        public async Task AddEntertainmentModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new AddEntertainmentModelDTO()
            {
                Title = "Entertainmnent11",
                Description = "Default description",
                Type = "Club",
                Address = new AddressModelDTO()
                {
                    StreetName = "soborna",
                    HouseNumber = "43",
                    ApartmentNumber = "3"
                }
            };

            var entertainment = await entertainmentService.AddEntertainmentModel(dto);
            Assert.IsNotNull(entertainment);
            Assert.AreEqual(dto.Title, entertainment.Title);
            Assert.AreEqual(dto.Description, entertainment.Description);
            Assert.AreEqual(dto.Type, entertainment.Type.ToString());
            Assert.AreEqual(dto.Address.ToString(), entertainment.Address.ToString());
        }
        [Test]
        public async Task AddEventtModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new AddEventModelDTO()
            {
                EntertainmentTitle = "Entertainment1",
                Title = "Event1",
                Price = new PriceModelDTO()
                {
                    Value = 100,
                    Tax = 10,
                    VAT = 1
                },
                Description = "desc1"


            };
            var eventModel = await entertainmentService.AddEventModel(dto);
            var eventFromContext = TestHelper.ApplicationContext.Events.FirstOrDefault(x => x.Title == dto.Title);

            Assert.IsNotNull(eventModel);
            Assert.AreEqual(eventModel.Title, eventFromContext.Title);
            Assert.AreEqual(eventModel.Description, eventFromContext.Description);
            Assert.AreEqual(eventModel.Price.Total, eventFromContext.Price.Total);
        }
        [Test]
        public async Task UpdadeEntertainmentModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);

            var dto = new UpdateEntertainmentDTO()
            {
                Title = "Entertainment1",
                Address = new AddressModelDTO()
                {
                    StreetName = "soborna",
                    HouseNumber = "43",
                    ApartmentNumber = "3"
                },
                Description = "Desc1",
                Type = "Exhibition"
            };

            var entertainment = await entertainmentService.UpdadeEntertainmentModel(dto);
            var entertainmentFromContext = TestHelper.ApplicationContext.Entertaiments.FirstOrDefault(x => x.Title == dto.Title);


            Assert.IsNotNull(entertainment);
            Assert.AreEqual(entertainment.Title, entertainmentFromContext.Title);
            Assert.AreEqual(entertainment.Type, entertainmentFromContext.Type);
            Assert.AreEqual(dto.Address.ToString(), entertainment.Address.ToString());
        }
    
        [Test]
        public async Task UpdateEventModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);

            var dto = new UpdateEventDTO()
            {
                Title = "Event1",
                Price = new PriceModelDTO()
                {
                    Tax = 111,
                    Value = 11,
                    VAT = 1
                },
                isAvailable =true
            };


            var events = await entertainmentService.UpdateEventModel(dto);
            var eventsFromContext = TestHelper.ApplicationContext.Events.FirstOrDefault(x => x.Title == dto.Title);


            Assert.IsNotNull(events);
            Assert.AreEqual(dto.Title, events.Title);
            Assert.AreEqual(dto.Price.Total, events.Price.Total);
        }
    //[Test]
    //public async Task DeleteEntertainmentModelTest()
    //{
    //    var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
    //    var dto = new DeleteEntertainmentDTO()
    //    {
    //        Title = "Entertainment1",
    //    };
    //    var entertainment = await entertainmentService.DeleteEntertainmentModel(dto);
    //    var entertainmentFromContext = TestHelper.ApplicationContext.Entertaiments.FirstOrDefaultAsync(x => x.Title == dto.Title);

    //    Assert.IsTrue(entertainment);

    //}
    //[Test]
    //public async Task DeleteEventModelTest()
    //{
    //    var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

    //    var dto = new DeleteEventDTO()
    //    {
    //        Title = "Entertainment1",
    //        EventTitle = "Event1"
    //    };

    //    var events = await entertainmentService.DeleteEventModel(dto);
    //    var eventFromContext = TestHelper.ApplicationContext.Events.FirstOrDefaultAsync(x => x.Title == dto.EventTitle);

    //    Assert.IsTrue(events);
    //}

    //[Test]
    //public void AddEventtModelEventExistsTest()
    //{
    //    var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
    //    var dto = new AddEventModelDTO()
    //    {

    //        EventTitle = "Event1",
    //        Value = 100.00,
    //        Tax = 10.00,
    //        VAT = 10.00
    //    };

    //    var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.AddEventModel(dto));
    //    Assert.AreEqual(exept.Message, "Event already exists");
    //}
    //[Test]
    //public void UpdadeEntertainmentModelEntertainmentNotExistsTest()
    //{
    //    var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

    //    var dto = new UpdateEntertainmentDTO()
    //    {
    //        EntertainmentTitle = " ",
    //    };


    //    var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.UpdadeEntertainmentModel(dto));
    //    Assert.AreEqual(exept.Message, "Entertainment Service is not exists");
    //}
    //[Test]
    //public void UpdateEventModelEventNotExistsTest()
    //{
    //    var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

    //    var dto = new UpdateEventDTO()
    //    {
    //        EventTitle = " ",
    //        Value = 300,
    //        Tax = 10,
    //        VAT = 10,
    //    };

    //    var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.UpdateEventModel(dto));
    //    Assert.AreEqual(exept.Message, "Event was not created!");
    //}
    //[Test]
    //public void DeleteEntertainmentModelEntertainmentNotExistTest()
    //{
    //    var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
    //    var dto = new DeleteEntertainmentDTO()
    //    {
    //        Title = " ",
    //    };

    //    var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.DeleteEntertainmentModel(dto));
    //    Assert.AreEqual(exept.Message, "Enterainment doesn't exists");
    //}

    //[Test]
    //public void DeleteEventModelEventNotExistTest()
    //{
    //    var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

    //    var dto = new DeleteEventDTO()
    //    {
    //        Title = "Entertainment1",
    //        EventTitle = ""
    //    };

    //    var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.DeleteEventModel(dto));
    //    Assert.AreEqual(exept.Message, "Event doesn't exist");
    //}

    //[Test]
    //public async Task SelectEntertainmentTest()
    //{

    //}*/

    }
}
