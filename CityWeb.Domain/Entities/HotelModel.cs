using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class HotelModel : Entity, IDescribe
    {
        public virtual ServiceModel Service { get; set; }
        public virtual Guid ServiceId { get; set; } 
        public virtual AddressModel RentAddress { get; set; }
        public virtual ICollection<RoomModel> Rooms { get; set; } = new List<RoomModel>();
        public string Title { get ; set ; }
        public string Description { get ; set ; }
        public string Image { get; set; }
        public override string ToString()
        {
            return $"Hotel {Title}\n{Description}\n{RentAddress.ToString()}";
        }
    }
}
