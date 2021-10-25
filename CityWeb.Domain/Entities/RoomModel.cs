using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class RoomModel : Entity
    {
        public virtual HotelModel Hotel { get; set; }
        public virtual HotelRoomType Type { get; set; }
        public bool IsFree { get; set; } = true;
        public int Number { get; set; }
        public virtual Guid HotelId { get; set; } = Guid.NewGuid();
        public virtual PriceModel Price { get; set; }
        public virtual PeriodModel RentPeriod { get; set; }
        public string Image { get; set; }

    }
}
