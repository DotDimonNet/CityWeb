using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class CounterModel : Entity
    {
        public string Number { get; set; }
        public virtual AddressModel Address { get; set; }
        public virtual HousePaymentType Type { get; set; }
        public virtual HousePayModel HousePayment { get; set; }
        public virtual Guid HousePaymentId { get; set; }
        public virtual PriceModel Price { get; set; }
        public virtual PaymentModel Payment { get; set; }
        public double PriceByItem { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }
       
    }
}
