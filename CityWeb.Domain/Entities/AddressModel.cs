using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class AddressModel : Entity
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
