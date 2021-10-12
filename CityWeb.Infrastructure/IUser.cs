using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure
{
    public interface IUser
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public double Balance { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string  PaymentCardID { get; set; }
        //public IEnumerable<object> AvailableService { get; set; }
    }
}
