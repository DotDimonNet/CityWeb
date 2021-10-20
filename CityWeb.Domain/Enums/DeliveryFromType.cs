using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public class DeliveryFromType : Enumeration
    {
        public static readonly DeliveryFromType Restaurant = new(1, "Restaurant");
        public static readonly DeliveryFromType FoodMarket = new(2, "FoodMarket");
        public static readonly DeliveryFromType FastFood = new(3, "FastFood");
      

        protected DeliveryFromType(int id, string name) : base(id, name) { }
    }
    
}
