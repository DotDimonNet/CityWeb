using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HouseBillDTO;
using CityWeb.Infrastructure.Service;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class HouseBillServiceTest
    {
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }

        [Test]
        public async Task CreateHHouseBillTest()
        {
            var houseBillService = new HouseBillService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new CreateHouseBillModelDTO()
            {
                Title = "Payment for Gas",
                Description = "October"
            };

            var houseBill = await houseBillService.CreateHouseBill(dto);
            var counterFromContext = TestHelper.ApplicationContext.HouseBills.FirstOrDefault(x => x.Title == houseBill.Title);

            Assert.IsNotNull(houseBill);
            Assert.AreEqual(houseBill.Title, counterFromContext.Title);
            Assert.AreEqual(houseBill.Description, counterFromContext.Description);
        }

        [Test]
        public void DeleteHouseBillTest()
        {
            var housePayService = new HouseBillService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new DeleteHouseBillModelDTO()
            {
                Title = "HouseBill1",
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await housePayService.DeleteHouseBill(dto));
            Assert.AreEqual(exept.Message, "HouseBill does not exist!");
        }
    }
}