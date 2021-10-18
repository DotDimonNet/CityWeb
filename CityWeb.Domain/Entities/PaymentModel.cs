using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.Entities
{
    public class PaymentModel : Entity
    {
        public virtual ApplicationUserModel Owner { get; set; }
        public virtual DiscountModel Discount { get; set; }
        public virtual PriceModel Price { get; set; }
        public virtual RatingModel Rating { get; set; }
        public virtual PaymentStatus Status { get; set; }
    }   
}

