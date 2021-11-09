using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HouseBillDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Service;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class HouseBillServiceTest
    {
        private ILogger<HouseBillService> _logger;
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _logger = TestHelper.SetupTestLogger<HouseBillService>();
        }

        [Test]
        public async Task CreateHHouseBillTest()
        {
            var houseBillService = new HouseBillService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new CreateHouseBillModelDTO()
            {
                Title = "Payment for Gas",
                Description = "October",
                HouseHoldAddress = new AddressModelDTO(),
            };

            var houseBill = await houseBillService.CreateHouseBill(dto);
            var counterFromContext = TestHelper.ApplicationContext.HouseBills.FirstOrDefault(x => x.Title == houseBill.Title);

            Assert.IsNotNull(houseBill);
            Assert.AreEqual(houseBill.Title, counterFromContext.Title);
            Assert.AreEqual(houseBill.Description, counterFromContext.Description);
        }

        [Test]
        public async Task UpdateHouseBillTest()
        {
            var houseBillService = new HouseBillService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var houseBillId = TestHelper.ApplicationContext.HouseBills.FirstOrDefault(x => x.Title == "houseBill1");
            var houseBillDTO = new UpdateHouseBillModelDTO()
            {
                Id = houseBillId.Id,
                Description = "Bill for last mounth",
                Address = new AddressModelDTO()
                {
                    StreetName = "Soborna",
                    HouseNumber = "24",
                    ApartmentNumber = "7"

                },
            };
            var houseBill = await houseBillService.UpdateHouseBill(houseBillDTO);

            Assert.IsNotNull(houseBill);
        }


            [Test]
        public async Task DeleteHouseBillTest()
        {
            var housePayService = new HouseBillService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new DeleteHouseBillModelDTO()
            {
                //HouseBillId = houseBillId.Id,
            };

            //await houseBillService.DeleteHouseBill(dto);
            var houseBillFromContext = TestHelper.ApplicationContext.HouseBills.FirstOrDefault(x => x.Id == dto.HouseBillId);
            Assert.IsNull(houseBillFromContext);
        }
    }
}