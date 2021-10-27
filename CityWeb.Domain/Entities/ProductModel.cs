using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class ProductModel : Entity
    {
        
        public string ProductName { get; set; }
        public virtual ProductType ProductType { get; set; }
        public int ProductCount { get; set; }
        public string ProductImage { get; set; }
        public virtual PriceModel ProductPrice { get; set; }
        public virtual DeliveryModel Delivery { get; set; }
        public virtual Guid DeliveryId { get; set; } 

    }
}
