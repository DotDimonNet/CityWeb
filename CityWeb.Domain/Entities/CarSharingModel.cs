using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class CarSharingModel: Entity, IDescribe
    {
        public string Title { get; set; }
        public string Description { get; set; }

        //public virtual ServiceModel Service { get; set; }
        //public virtual Guid ServiceId { get; set; }
        public virtual AddressModel Location { get; set; }
        public virtual ICollection<RentCarModel> Vehicle { get; set; } = new List<RentCarModel>();
        public virtual PaymentModel Payment { get; set; }
        
    }
}
