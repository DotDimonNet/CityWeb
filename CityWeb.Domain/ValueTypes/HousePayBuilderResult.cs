using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.ValueTypes
{
    public class HousePayBuilderResult
    {
        //Step 1
        public string HousePaymentTitle { get; set; }
        public AddressModel HousePaymentAddress { get; set; }
        //Step 2 
        public string PaymentInfo { get; set; }
        public PriceModel Price { get; set; }
        public  HousePaymentType HousePaymnet{ get; set; }
        //Step 3
        public int Number { get; set; }
        public double StartCount { get; set; }
        public double EndVCount { get; set; }
        //Step 4




        //PaymentButton

    }
}
