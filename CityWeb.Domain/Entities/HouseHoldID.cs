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
        //public virtual ApplicationUserModel Owner { get; set; }
        public virtual HousePaymentType PaymentType { get; set; }
        public virtual CounterModel Counter { get; set; }
        public virtual AddressModel PayerAddress { get; set; }
        public virtual PriceModel Price { get; set; }
        public virtual PaymentModel Payment { get; set; }
        public virtual HousePayModel Destributor { get; set; }
        public virtual Guid DestributorId { get; set; }
    }
}
