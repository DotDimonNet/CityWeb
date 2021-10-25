using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Domain.ValueTypes;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Service
{
    public class HotelService
    {
        private readonly ApplicationContext _context;
        public HotelService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<RoomDTO> AddRoom(RoomDTO room)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == room.HotelId);
            if(hotel != null)
            {
                hotel.Rooms.Add(
                    new RoomModel()
                    {
                        HotelId = room.HotelId,
                        Number = room.Number,
                        Price = room.Price,
                        Type = room.Type,
                    });
                _context.Update(hotel);
                await _context.SaveChangesAsync();
                return room;
            }
            else
            {
                throw new Exception("Hotel does not exist!");
            }

        }
        public async Task<HotelDTO> AddHotel(HotelDTO hotelDTO)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == hotelDTO.Title);
            if (hotel == null)
            {
                //code
                return hotelDTO;
            }
            else
            {
                throw new Exception("Hotel with this title already exist!");
            }
        }

       /* public async Task<HotelBuilderResult> GoNext(HotelBuilderResult builderResultModel, int step = 1)
        {
            switch (step)
            {
                case 1:
                    return await StepOne(builderResultModel);
                case 2:
                    return await StepTwo(builderResultModel);
                default:
                    return new HotelBuilderResult();
            }
        }*/



        public async Task<HotelBuilderResult> StepOne(string hotelTitle)
        {
            var result =  new HotelBuilderResult();
            result.HotelTitle = hotelTitle;
            var roomTypes = await _context.Rooms.Where(x => x.Hotel.Title == result.HotelTitle ).Select(x => x.Type).Distinct().ToListAsync();
            //Front-end simulation 
            foreach(var type in roomTypes)
            {
                Console.WriteLine(type);
            }
            return result;
        }
        public async Task<HotelBuilderResult> StepTwo(HotelBuilderResult result, HotelRoomType type )
        {
            result.RoomType = type;
            var rooms = _context.Rooms.Where(x => x.Hotel.Title == result.HotelTitle && x.IsFree && x.Type == result.RoomType);
            
            return result;
        }
        public async Task<HotelBuilderResult> StepThree(HotelBuilderResult result, int roomNum)
        {
            result.RoomNumber = roomNum ;
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Title == result.HotelTitle && x.Number == result.RoomNumber);
            result.TotalPrice = room.Price.Total;
            

            return result;
        }

    }
}
