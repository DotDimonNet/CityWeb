﻿using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.Transport.Car
{
    public class UpdateTaxiCarDTO
    {
        //public string TaxiTitle { get; set }
        public string VINCode { get; set; }

        public TransportType Type { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public string Number { get; set; }
    }
}