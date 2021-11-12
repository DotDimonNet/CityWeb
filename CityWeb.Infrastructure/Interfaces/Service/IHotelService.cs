using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface IHotelService
    {
        public Task<IEnumerable<HotelDTO>> GetAllHotels();
        public Task<IEnumerable<RoomDTO>> GetAllRooms();
        public Task<RoomModel> UpdateRoom(UpdateRoomDTO DTO);
        public Task<HotelModel> UpdateHotel(HotelDTO DTO);
        public Task<bool> RemoveHotel(DeleteHotelDTO hotelDTO);
        public Task<HotelModel> AddHotel(HotelDTO hotelDTO);
        public Task<bool> RemoveRoom(DeleteRoomDTO room);
        public Task<RoomModel> AddRoom(RoomDTO DTO);
        public Task<HotelModel> FindHotelById(HotelIdDTO DTO);
        public Task<HotelModel> FindHotelByTitle(HotelTitleDTO DTO);
        public Task<List<HotelRoomType>> GetAllRoomTypesByHotelTitle(HotelTitleDTO DTO);
        // Methods for steps    
        public Task<ICollection<RoomModel>> GetAllFreeRooms(HotelTitleDTO DTO);
        public Task<RoomModel> GetSelectedRoom(int roomNum);
        public Task<HotelBuilderResult> GetHotelResult(DateTime starDate, DateTime endDate);

    }
}
