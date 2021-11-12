using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class UserProfileModelDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public AddressModelDTO Address { get; set; }
    }
}
