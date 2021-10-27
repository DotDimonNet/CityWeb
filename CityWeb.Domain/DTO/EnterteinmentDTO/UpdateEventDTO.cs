﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class UpdateEventDTO
    {
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public PriceModel Price { get; set; }
    }
}
