using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Domain.Entities;
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
        
    }
}
