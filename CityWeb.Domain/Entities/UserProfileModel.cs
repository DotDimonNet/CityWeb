using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class UserProfileModel : Entity
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public virtual AddressModel Address { get; set; }
        public virtual ApplicationUserModel User { get; set; }
    }
}
