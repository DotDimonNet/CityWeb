using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class HousePayModel : Entity
    {
        public virtual ServiceModel Service { get; set; }
        public virtual HousePaymentType ServiceType { get; set; }
        public virtual CounterModel Counter { get; set; }
        public virtual AddressModel PayerAddress { get; set; }
        public virtual PriceModel Price { get; set; }
    }
}
