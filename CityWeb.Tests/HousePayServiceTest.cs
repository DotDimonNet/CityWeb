using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HousePayDTO;
using CityWeb.Infrastructure.Service;
using CityWeb.Infrastructure.Service.Transport;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class HousePayServiceTest
    {
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }

        [Test]
        public async Task CreateHHousePayTest()
        {
            var housePayService = new HousePayService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new CreateHousePayModelDTO()
            {
                Title = "Payment for Gas",
                Description = "October"
            };

            var housePay = await housePayService.CreateHousePayModel(dto);
            var counterFromContext = TestHelper.ApplicationContext.HousePays.FirstOrDefault(x => x.Title == housePay.Title);

            Assert.IsNotNull(housePay);
            Assert.AreEqual(housePay.Title, counterFromContext.Title);
            Assert.AreEqual(housePay.Description, counterFromContext.Description);
        }

        [Test]
        public void DeleteHousePayTest()
        {
            var housePayService = new HousePayService(TestHelper.ApplicationContext, TestHelper.TestMapper);
            var dto = new DeleteHousePayModelDTO()
            {
                Title = "HousePay1",
            };

            var exept = Assert.ThrowsAsync<Exception>(async () => await housePayService.DeleteHousePay(dto));
            Assert.AreEqual(exept.Message, "HousePay does not exist!");
        }
    }
}