using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IUser: IBaseDBO, IAuthInfo
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public IEnumerable<IBalance> Balances { get; set; }
        public IEnumerable<IRating> Ratings { get; set; }
        public DateTime RegistrationDate { get; set; }
        public IAddress Address { get; set; }
    }
}
