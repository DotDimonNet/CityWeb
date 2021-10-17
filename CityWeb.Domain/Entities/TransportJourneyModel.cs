using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class TransportJourneyModel : Entity
    {
        public virtual PaymentModel Payment { get; set; }
        public virtual VehicleModel Vehicle { get; set; }
    }
}
