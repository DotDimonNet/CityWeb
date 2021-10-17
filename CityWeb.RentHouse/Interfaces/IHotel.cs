using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.RentHouse.Interfaces
{
    public interface IHotel //: IRentHouseService
    {
        public HotelRoomType RoomType { get; set; }
        public IDictionary<HotelRoomType,int> RoomsQuantity { get; set; }



    }
}
