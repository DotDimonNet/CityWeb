using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class RestaurantModel : Entity, IDescribe
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual AddressModel RestaurantAdress { get; set; }
        public int FreePlaces { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        
    }
}
