using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class DeliveryModel : Entity
    {
        public virtual ServiceModel Service { get; set; }
        public virtual DeliveryFromType DeliveryFrom { get; set; }
        public virtual AddressModel DeliveryAdress { get; set; }
        public virtual PeriodModel WorkSchedule { get; set; }
        public virtual ICollection<ProductModel> Order { get; set; } = new List<ProductModel>();
        public virtual PriceModel DeliveryPrice { get; set; }
        public virtual ApplicationUserModel User { get; set; }

    }
}
