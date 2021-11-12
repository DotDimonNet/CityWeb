﻿using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class BusketModelDTO
    {
        public ICollection<BusketItemModelDTO> Busket { get; set; } = new List<BusketItemModelDTO>();
        public string Name { get; set; }
        public AddressModelDTO Address { get; set; }
    }
}
