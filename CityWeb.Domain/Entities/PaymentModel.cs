using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.Entities
{
    public class PaymentModel : Entity, IDescribe
    {
        public virtual ApplicationUserModel Owner { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual DiscountModel Discount { get; set; }
        public double Price { get; set; }
        public virtual PaymentStatus Status { get; set; }
        public string Title { get; set ; }
        public string Description { get ; set ; }
    }   
}

