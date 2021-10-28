using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Infrastructure.Service;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class HotelServiceTests
    {
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }

        [Test]
        public async Task CreateHotelTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext);
            var dto = new HotelDTO()
            {
                Title = "Hotel Paradise",
                Description = "Default description"
            };

            var hotel = await hotelService.AddHotel(dto);
            var hotelFromContext = TestHelper.ApplicationContext.Hotels.FirstOrDefault(x => x.Id == hotel.Id);

            Assert.IsNotNull(hotel);
            Assert.AreEqual(hotel.Description, hotelFromContext.Description);
            Assert.AreEqual(hotel.Title, hotelFromContext.Title);
        }
    }
}
