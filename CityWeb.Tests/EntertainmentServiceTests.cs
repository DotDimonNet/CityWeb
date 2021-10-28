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
            var dto = new AddEntertainmentModelDTO()
            {
                EntertainmentTitle = "Lounge bar",
                Description = "Default description"
            };

            var entertainment = await entertainmentService.AddEntertainmentModel(dto);
            var entertainmentFromContext = TestHelper.ApplicationContext.Entertaiments.FirstOrDefault(x => x.Id == entertainment.EntertainmentId);

            Assert.IsNotNull(entertainment);
            Assert.AreEqual(entertainment.Description, entertainmentFromContext.Description);
            Assert.AreEqual(entertainment.EntertainmentTitle, entertainmentFromContext.Title);
        }
        [Test]
        public async Task UpdadeEntertainmentModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new UpdateEntertainmentDTO()
            {
                EntertainmentTitle = $"Entertainment1",        
            };
            
            var entertainment = await entertainmentService.UpdadeEntertainmentModel(dto);
            var entertainmentFromContext = TestHelper.ApplicationContext.Entertaiments.FirstOrDefault(x => x.Title == entertainment.EntertainmentTitle);


            Assert.IsNotNull(entertainment); 
            Assert.AreEqual(entertainment.EntertainmentTitle, entertainmentFromContext.Title);

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
            var entertainmentFromContext =  TestHelper.ApplicationContext.Entertaiments.FirstOrDefaultAsync(x => x.Title == dto.Title);

            Assert.IsTrue(entertainment);
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


        //[Test]
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
