using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class HouseHoldID : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual UserProfileModel Owner { get; set; }
        public virtual ServiceModel Service { get; set; }
        public virtual HousePaymentType PaymentType { get; set; }
        public double CurrentValue  { get; set; }
        public double PaidValue { get; set; }
        public double PricewPerItem { get; set; }
    }
}
