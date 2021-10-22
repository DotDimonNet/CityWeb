using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.Transport.Car
{
    public class AddTaxiCarDTO
    {
        public string TaxiTitle { get; set; }
        public string VINCode { get; set; }

        public TransportType Type { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public string Number { get; set; }
        //public TaxiCarModel Car { get; set; }
    }
}
