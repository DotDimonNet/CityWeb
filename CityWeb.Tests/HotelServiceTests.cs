﻿using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Service;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class HotelServiceTests
    {
        private ILogger<HotelService> _logger;

        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _logger = TestHelper.SetupTestLogger<HotelService>();
        }

        [Test]
        public async Task AddHotelTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new HotelDTO()
            {
                Title = "Hotel Paradise",
                Description = "Default description",
                Image = "Hotel_img97.png",
                Address = new HotelAddressDTO()
                {
                    HouseNumber = "123a",
                    StreetName = "Chehova"
                }
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
        public async Task AddHotelExeptionTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new HotelDTO()
            {
                Title = TestHelper.ApplicationContext.Hotels.Select(x => x.Title).FirstOrDefault(),
            };
            var exept = Assert.ThrowsAsync<Exception>(async () => await hotelService.AddHotel(dto));
            Assert.AreEqual(exept.Message, "Hotel with this title already exist!");
        }

        [Test]
        public async Task AddRoomTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new RoomDTO()
            {
                HotelTitle = "Hotel 2",
                Number = 123,
                Image = "Room_img97.png",
                Type = HotelRoomType.Delux.ToString(),
                Price = new PriceDTO
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

        [Test]
        public async Task AddRoomExeptionTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var dto = new RoomDTO()
            {
                HotelTitle = String.Empty,
                Number = TestHelper.ApplicationContext.Rooms.Select(x => x.Number).FirstOrDefault(),
            };
            var exept = Assert.ThrowsAsync<Exception>(async () => await hotelService.AddRoom(dto));
            Assert.AreEqual(exept.Message, "Hotel does not exist!");
            dto.HotelTitle = TestHelper.ApplicationContext.Hotels.Select(x => x.Title).FirstOrDefault();
            exept = Assert.ThrowsAsync<Exception>(async () => await hotelService.AddRoom(dto));
            Assert.AreEqual(exept.Message, "Room with this number already exist!");
        }

        [Test]
        public async Task FindHotelByIdTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var hotelIdFromContext = TestHelper.ApplicationContext.Hotels.Select(x => x.Id).FirstOrDefault();

            var hotel = await hotelService.FindHotelById(new HotelIdDTO { Id = hotelIdFromContext });

            Assert.IsNotNull(hotel);
        }

        [Test]
        public async Task FindHotelByIdExeptionTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var exept = Assert.ThrowsAsync<Exception>(async () => await hotelService.FindHotelById(new HotelIdDTO() { Id = Guid.NewGuid() }));
            Assert.AreEqual(exept.Message, "Hotel with this ID doesnt exist!");
        }

        [Test]
        public async Task FindHotelByTitleTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var hotelTitleFromContext = TestHelper.ApplicationContext.Hotels.Select(x => x.Title).FirstOrDefault();

            var hotel = await hotelService.FindHotelByTitle(new HotelTitleDTO { Title = hotelTitleFromContext });

            Assert.IsNotNull(hotel);
        }

        [Test]
        public async Task FindHotelByTitleExeptionTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var exept = Assert.ThrowsAsync<Exception>(async () => await hotelService.FindHotelByTitle(new HotelTitleDTO() { Title = String.Empty }));
            Assert.AreEqual(exept.Message, "Hotel with this title doesnt exist!");
        }
        [Test]
        public async Task RemoveHotelTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger);
            var hotel = TestHelper.ApplicationContext.Hotels.FirstOrDefault();
            var dto = new DeleteHotelDTO()
            {
                Title = hotel.Title,
            };
            await hotelService.RemoveHotel(dto);
            Assert.IsNull(TestHelper.ApplicationContext.Hotels.FirstOrDefault(x => x.Id == hotel.Id));
        }
        [Test]
        public async Task RemoveHotelExeptionTest()
        {
            var hotelService = new HotelService(TestHelper.ApplicationContext, TestHelper.TestMapper, _logger    );
            var dto = new DeleteHotelDTO()
            {
                Title = "",
            };
            var exept = Assert.ThrowsAsync<Exception>(async () => await hotelService.RemoveHotel(dto));
            Assert.AreEqual(exept.Message, "Hotel with this title doesnt exist!");
        }
    }
}
