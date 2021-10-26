using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class UpdateUserDataDTO
    {
        public string Login { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Avatar { get; set; }
    }
}
