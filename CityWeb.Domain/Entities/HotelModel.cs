using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class HotelModel : Entity
    {
        public virtual ServiceModel Service { get; set; }
        public virtual AddressModel RentAddress { get; set; }
        public virtual ICollection<RoomModel> Rooms { get; set; }
    }
}
