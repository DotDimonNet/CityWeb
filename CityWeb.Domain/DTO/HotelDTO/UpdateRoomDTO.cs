using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.HotelDTO
{
    public class UpdateRoomDTO
    {
        public string Type { get; set; }
        public int Number { get; set; }
        public PriceDTO Price { get; set; }
        public string HotelTitle { get; set; }
        public string Image { get; set; }
        public PeriodModelDTO RentPeriod { get; set; }
        public bool IsFree { get; set; }

        //public ApplicationUserModel User { get; set; }
    }
}
