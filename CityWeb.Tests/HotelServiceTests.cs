using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
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
        public async Task AddHotelTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext);
            var dto = new HotelDTO()
            {
                Title = "Hotel Paradise",
                Description = "Default description",
                Image = "Hotel_img97.png",
                StreetName = "Soborna",
                HouseNumber = "123a",
            };

            var hotel = await hotelService.AddHotel(dto);
            var hotelFromContext = TestHelper.ApplicationContext.Hotels.FirstOrDefault(x => x.Id == hotel.Id);

            Assert.IsNotNull(hotel);
            Assert.AreEqual(hotel.Image, hotelFromContext.Image);
            Assert.AreEqual(hotel.RentAddress.StreetName, hotelFromContext.RentAddress.StreetName);
            Assert.AreEqual(hotel.RentAddress.HouseNumber, hotelFromContext.RentAddress.HouseNumber);
            Assert.AreEqual(hotel.Description, hotelFromContext.Description);
            Assert.AreEqual(hotel.Title, hotelFromContext.Title);
        }
        [Test]
        public async Task AddRoomTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext);
            var dto = new RoomDTO()
            {
                HotelTitle = "Hotel 1",
                Number = 123,
                Image = "Room_img97.png",
                Type = HotelRoomType.Delux,
                Price = new PriceModel
                {
                    Value = 1234
                }
            };
            var room = await hotelService.AddRoom(dto);
            var roomFromContext = TestHelper.ApplicationContext.Rooms.FirstOrDefault(x => x.Id == room.Id);

            Assert.IsNotNull(room);
            Assert.AreEqual(room.Image, roomFromContext.Image);
            Assert.AreEqual(room.Type, roomFromContext.Type);
            Assert.AreEqual(room.Price.Value, roomFromContext.Price.Value);
            Assert.AreEqual(room.Number, roomFromContext.Number);
        }
    }
}
