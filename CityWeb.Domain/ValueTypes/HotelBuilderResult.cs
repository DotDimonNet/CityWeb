using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.ValueTypes
{
    public class HotelBuilderResult
    {
        //Step 1
        public string HotelTitle{ get; set; }
        //Step 2
        public HotelRoomType RoomType { get; set; }
        //Step 3
        public int RoomNumber { get; set; }
        public double TotalPrice{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
