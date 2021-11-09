using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Domain.DTO;

namespace CityWeb.Domain.ValueTypes
{
    public class HouseBillBuilderResult
    {
        public string HouseBillType { get; set; }
        public  CounterModelDTO Counter{ get; set; }
        public int Number { get; set; }
        public double StartCount { get; set; }
        public double EndVCount { get; set; }
        public double PricePerItem { get; set; }
        public AddressModelDTO HouseAdress { get; set; }
    }
}
