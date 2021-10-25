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
        public string Title { get; set; }
        public string Description { get; set; }
        //step 2
        public RentCarModel Car { get; set; }//???
        //step 3
        public PeriodModel Period { get; set; }
        public PaymentModel Payment { get; set; }//???
    }
}
