﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class UpdateUserDataDTO
    {
        public string UserName { get; set; }
        public UserProfileModelDTO Profile { get; set; }
        public AddressModelDTO Address { get; set; }
    }
}
