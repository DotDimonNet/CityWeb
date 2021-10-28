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
        private HotelBuilderResult _builderResult;
        private readonly ApplicationContext _context;
        public HotelService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<RoomModel> AddRoom(RoomDTO room)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == room.HotelTitle);
            if(hotel != null)
            {
                var newRoom = new RoomModel()
                {
                    Number = room.Number,
                    Price = room.Price,
                    Type = room.Type,
                    HotelId = hotel.Id,
                    RentPeriod = new PeriodModel
                    {

                    },                    
                    Image = room.Image,
                };
                await _context.Rooms.AddAsync(newRoom);
                await _context.SaveChangesAsync();
                return newRoom;
            }
            else
            {
                throw new Exception("Hotel does not exist!");
            }
        }
        public async Task RemoveRoom(DeleteRoomDTO room)
        {
            var removeRoom = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Id == room.HotelId && x.Hotel.Title == room.HotelTitle && x.Number == room.RoomNumber);
            if (room != null)
            {             
                _context.Rooms.Remove(removeRoom);
                _context.Update(_context.Rooms);
                await _context.SaveChangesAsync();
                return;
            }
            else
            {
                throw new Exception("Hotel does not exist!");
            }
        }

        public async Task<HotelModel> AddHotel(HotelDTO hotelDTO)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == hotelDTO.Title);
            if (hotel == null)
            {
                var newHotel = new HotelModel
                {
                    Image = hotelDTO.Image,
                    Description = hotelDTO.Description,
                    Title = hotelDTO.Title,  
                    RentAddress = new AddressModel
                    {
                        StreetName = hotelDTO.StreetName,
                        HouseNumber = hotelDTO.HouseNumber,
                    },     
                };
                await _context.Hotels.AddAsync(newHotel);                
                await _context.SaveChangesAsync();
                return newHotel;
            }
            else
            {
                throw new Exception("Hotel with this title already exist!");
            }
        }
        public async Task RemoveHotel(DeleteHotelDTO hotelDTO)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Title == hotelDTO.HotelTitle && x.Id == hotelDTO.HotelId);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.Update(_context.Hotels);
                await _context.SaveChangesAsync();
                return;
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

        //Step 1
        public async Task<ICollection<RoomModel>> GetAllFreeRooms(string hotelTitle)
        {
            _builderResult.HotelTitle = hotelTitle;
            return await _context.Rooms.Where(x => x.Hotel.Title == hotelTitle && x.IsFree).ToListAsync();
        }
        //Step 2
        public async Task<RoomModel> GetSelectedRoom(int roomNum)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Title == _builderResult.HotelTitle && x.Number == roomNum);
            _builderResult.RoomNumber = roomNum;
            _builderResult.RoomType = room.Type;
            _builderResult.Image = room.Image;
            return room;
        }
        //Final step
        public async Task<HotelBuilderResult> GetHotelResult(DateTime starDate, DateTime endDate)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Hotel.Title == _builderResult.HotelTitle && x.Number == _builderResult.RoomNumber);
            _builderResult.StartDate = starDate;
            _builderResult.EndDate = endDate;
            _builderResult.DaysAmount = (endDate - starDate).Days;
            //HotelPayment(room.Price,_builderResult.DaysAmount ); //Not realised yet.
            _builderResult.TotalPrice = room.Price.Total;
            return _builderResult;
        }


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
