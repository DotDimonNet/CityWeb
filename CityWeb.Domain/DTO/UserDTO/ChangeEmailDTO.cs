﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class ChangeEmailDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }

    }
}
