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
        //step 1
        public string CarSharingTitle { get; set; }
        public string CarSharingDescription { get; set; }//???
        //step 2
        public RentCarModel Car { get; set; }
        //step 3
        public PeriodModel RentPeriod { get; set; }
        public double Price { get; set; }
        public AddressModel Location { get; set; }
    }
}
