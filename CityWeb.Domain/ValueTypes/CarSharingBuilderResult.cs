using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.Transport.Car;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.ValueTypes
{
    public class CarSharingBuilderResult
    {
        public string CarSharingTitle { get; set; }
        public string CarSharingDescription { get; set; }
        public RentCarsModelDTO Car { get; set; }
        public PeriodModelDTO RentPeriod { get; set; }
        public double Price { get; set; }
        public AddressModelDTO Location { get; set; }
    }
}
