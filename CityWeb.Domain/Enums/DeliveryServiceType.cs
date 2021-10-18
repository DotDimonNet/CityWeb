using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public class DeliveryServiceType : Enumeration
    {
        public static readonly DeliveryServiceType Torpedo = new(1, "Torpedo");
        public static readonly DeliveryServiceType Rocket = new(2, "Rocket");
        public static readonly DeliveryServiceType FirstDelivery = new(3, "FirstDelivery");

        protected DeliveryServiceType(int id, string name) : base(id, name) { }
    }
    
}
