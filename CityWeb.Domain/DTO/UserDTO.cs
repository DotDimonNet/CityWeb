﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Avatar { get; set; }
    }
}
