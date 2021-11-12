﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class EntertainmentModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public EntertainmentType Type { get; set; }
        public AddressModelDTO Address { get; set; }

    }
}
