using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.HotelDTO
{
    public class DeleteRoomDTO
    {
        public string HotelTitle { get; set; }
        public int RoomNumber { get; set; }
        public Guid HotelId { get; set; }
    }
}
