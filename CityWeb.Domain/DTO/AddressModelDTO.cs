using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.DTO
{
    public class AddressModelDTO
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public override string ToString()
        {
            return $"Street {StreetName} {HouseNumber} {ApartmentNumber}";
        }

    }
}
