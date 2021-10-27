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

        public async Task UpdadeEntertainmentModelTest()
        {
            var entertainmentService = new EntertainmentService(TestHelper.ApplicationContext);

            var dto = new UpdateEntertainmentDTO()
            {
                EntertainmentTitle = "Lounge bar",
                Description = "Default description",
                Type = EntertainmentType.Cinema,
                Address = new AddressModel()
                {
                    StreetName = "Soborna",
                    HouseNumber = "25A",
                    Id = Guid.NewGuid()
                }
            };

            var entertainment = await TestHelper.ApplicationContext.Entertaiments.FirstOrDefaultAsync(x => x.Title == dto.EntertainmentTitle);
            if (entertainment != null)
            {
                entertainment.Title = dto.EntertainmentTitle;
                entertainment.Description = dto.Description;
                entertainment.EntertainmentType = dto.Type;
                entertainment.Address = dto.Address;


            }
            var updateEntertainment = await entertainmentService.UpdadeEntertainmentModel(dto);
            var updateEntertainmentFromContext = TestHelper.ApplicationContext.Entertaiments.FirstOrDefault(x => x.Id == updateEntertainment.EntertainmentId);


            Assert.IsNotNull(updateEntertainment);
            Assert.AreEqual(updateEntertainment.Description, updateEntertainmentFromContext.Description);
            Assert.AreEqual(updateEntertainment.EntertainmentTitle, updateEntertainmentFromContext.Title);
        }
    }
}
