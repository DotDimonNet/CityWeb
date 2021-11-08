using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class UpdateUserPasswordDTO
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        
    }
}
