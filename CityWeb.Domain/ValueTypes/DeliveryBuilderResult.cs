using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.ValueTypes
{
    public class DeliveryBuilderResult
    {
        //Step 1
        public string DeliveryTitle { get; set; }
        

        //Step 2 
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int ProductCount { get; set; }
        public string ProductImage { get; set; }

        //Step 3
        public AddressModel DeliveryAddress {get; set;}
        //Step 4
    }
}
