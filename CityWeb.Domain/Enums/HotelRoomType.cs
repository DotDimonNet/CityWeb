using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public class HotelRoomType : Enumeration
    {
        public static readonly HotelRoomType Lux = new(1, "Lux");
        public static readonly HotelRoomType Delux = new(2, "Delux");
        public static readonly HotelRoomType Premium = new(3, "Premium");
        public static readonly HotelRoomType President = new(4, "President");
        public static readonly HotelRoomType Standart = new(5, "Standart");
        public static readonly HotelRoomType Econom = new(6, "Econom");

        protected HotelRoomType(int id, string name) : base(id, name) { }

    }
}
