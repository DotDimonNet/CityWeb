using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IAddress : IBaseDBO
    {
        public Guid OwnerId { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
