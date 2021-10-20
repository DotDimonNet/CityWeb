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
        public virtual ServiceModel Service { get; set; }
        public virtual AddressModel Location { get; set; }
        public virtual ICollection<VehicleModel> Vehicle { get; set; } = new List<VehicleModel>();
        //public virtual VehicleModel Vehicle { get; set; }
        public virtual PeriodModel RentPeriod { get; set; }
        public virtual PaymentModel Payment { get; set; }
       
    }
}
