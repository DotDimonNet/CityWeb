using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.EnterteinmentDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CityWeb.Tests
{
    public class EntertainmentServiceTests
    {
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }
        [Test]
        public async Task AddEntertainmentModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
            var dto = new EntertainmentModelDTO()
            {
                EntertainmentTitle = "Lounge bar",
                Description = "Default description"
            };

            var entertainment = await entertainmentService.AddEntertainmentModel(dto);
            var entertainmentFromContext = TestHelper.ApplicationContext.Entertaiments.FirstOrDefault(x => x.Title == entertainment.EntertainmentTitle);

            Assert.IsNotNull(entertainment);
            Assert.AreEqual(entertainment.Description, entertainmentFromContext.Description);
            Assert.AreEqual(entertainment.EntertainmentTitle, entertainmentFromContext.Title);
        }
        [Test]
        public async Task AddEventtModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
            var dto = new EventModelDTO()
            {
                Title = "Entertainment1",
                EventTitle = "asdvfdas",
                Value = 100.00,
                Tax = 10.00,
                VAT = 10.00
            };
            var events = await entertainmentService.AddEventtModel(dto);
            var eventFromContext = TestHelper.ApplicationContext.Events.FirstOrDefault(x => x.Title == events.EventTitle);

            Assert.IsNotNull(events);
            Assert.AreEqual(events.EventTitle, eventFromContext.Title);
        }
        [Test]
        public async Task UpdadeEntertainmentModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new EntertainmentModelDTO()
            {
                EntertainmentTitle = $"Entertainment1",
            };

            var entertainment = await entertainmentService.UpdadeEntertainmentModel(dto);
            var entertainmentFromContext = TestHelper.ApplicationContext.Entertaiments.FirstOrDefault(x => x.Title == entertainment.EntertainmentTitle);


            Assert.IsNotNull(entertainment);
            Assert.AreEqual(entertainment.EntertainmentTitle, entertainmentFromContext.Title);

        }
        [Test]
        public async Task UpdateEventModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new EventModelDTO()
            {
                Title = "Entertainment1",
                EventTitle = "Event1",
                Value = 300,
                Tax = 10,
                VAT = 10,
            };


            var events = await entertainmentService.UpdateEventModel(dto);
            var eventsFromContext = TestHelper.ApplicationContext.Events.FirstOrDefault(x => x.Title == events.EventTitle);


            Assert.IsNotNull(events);
            Assert.AreEqual(events.EventTitle, eventsFromContext.Title);
        }
        [Test]
        public async Task DeleteEntertainmentModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
            var dto = new DeleteEntertainmentDTO()
            {
                Title = "Entertainment1",
            };
            var entertainment = await entertainmentService.DeleteEntertainmentModel(dto);
            var entertainmentFromContext = TestHelper.ApplicationContext.Entertaiments.FirstOrDefaultAsync(x => x.Title == dto.Title);

            Assert.AreEqual(entertainment, "Entertainment was deleted");

        }
        [Test]
        public async Task DeleteEventModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new DeleteEventDTO()
            {
                Title = "Entertainment1",
                EventTitle = "Event1"
            };

            var events = await entertainmentService.DeleteEventModel(dto);
            var eventFromContext = TestHelper.ApplicationContext.Events.FirstOrDefaultAsync(x => x.Title == dto.EventTitle);

            Assert.IsTrue(events);
        }

        [Test]
        public void AddEventtModelEntertainmentNotExistTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
            var dto = new EventModelDTO()
            {
                Title = " ",
                EventTitle = "asdvfdas",
                Value = 100.00,
                Tax = 10.00,
                VAT = 10.00
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.AddEventtModel(dto));
            Assert.AreEqual(exept.Message, "Entertainment doesnt exist");
        }
        [Test]
        public void AddEventtModelEventExistsTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
            var dto = new EventModelDTO()
            {
                Title = "Entertainment1",
                EventTitle = "Event1",
                Value = 100.00,
                Tax = 10.00,
                VAT = 10.00
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.AddEventtModel(dto));
            Assert.AreEqual(exept.Message, "Event already exists");
        }
        [Test]
        public void UpdadeEntertainmentModelEntertainmentNotExistsTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new EntertainmentModelDTO()
            {
                EntertainmentTitle = " ",
            };


            var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.UpdadeEntertainmentModel(dto));
            Assert.AreEqual(exept.Message, "Entertainment doesnt exists");
        }
        [Test]
        public void UpdateEventModelEntertainmentNotExistsTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new EventModelDTO()
            {
                Title = " ",
                EventTitle = "Event1",
                Value = 300,
                Tax = 10,
                VAT = 10,
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.UpdateEventModel(dto));
            Assert.AreEqual(exept.Message, "Entertainment was not created!");
        }
        [Test]
        public void UpdateEventModelEventNotExistsTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new EventModelDTO()
            {
                Title = "Entertainment1",
                EventTitle = " ",
                Value = 300,
                Tax = 10,
                VAT = 10,
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.UpdateEventModel(dto));
            Assert.AreEqual(exept.Message, "Event was not created!");
        }
        [Test]
        public void DeleteEntertainmentModelEntertainmentNotExistTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
            var dto = new DeleteEntertainmentDTO()
            {
                Title = " ",
            };
            
            var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.DeleteEntertainmentModel(dto));
            Assert.AreEqual(exept.Message, "Enterainment doesnt exists");
        }
        [Test]
        public void DeleteEventModelEntertainmentNotExistTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new DeleteEventDTO()
            {
                Title = "",
                EventTitle = "Event1"
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.DeleteEventModel(dto));
            Assert.AreEqual(exept.Message, "Entertainment doesnt exist");
        }
        [Test]
        public void DeleteEventModelEventNotExistTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new DeleteEventDTO()
            {
                Title = "Entertainment1",
                EventTitle = ""
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await entertainmentService.DeleteEventModel(dto));
            Assert.AreEqual(exept.Message, "Event doesnt exist");
        }


        //public async Task StepOneTest()
        //{
        //    var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);
        //    var dto = new EntertainmentModel()
        //    {
        //        Title = $"Entertainment1",
        //        Description = $"Default description 1",
        //        Address = new AddressModel()
        //        {
        //            StreetName = "Soborna",
        //            HouseNumber = "25A"

        //        }
        //    };

        //    var entertainment = await entertainmentService.StepOne();
        //    var entertainmentFromContext = TestHelper.ApplicationContext.Services.FirstOrDefault(x => x.Entertaiments == entertainment);
        //}

    }


}
