using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class ServiceModel : Entity, IDescribe
    {
        public virtual PriceModel Price { get; set; }//?? PaymentModel
        public virtual ICollection<ServiceBranchModel> Branches { get; set; } = new List<ServiceBranchModel>();
        public virtual ICollection<ApplicationUserModel> Users { get; set; } = new List<ApplicationUserModel>();

        public string Title { get; set; }
        public string Description { get; set; }
        //New
        public virtual ICollection<EntertaimentModel> Entertaiments { get; set; } = new List<EntertaimentModel>();
        public virtual ICollection<DiscountModel> Discounts { get; set; } = new List<DiscountModel>();
        public virtual ICollection<DeliveryModel> Deliverys { get; set; } = new List<DeliveryModel>();
        public virtual ICollection<HousePayModel> HousePayments { get; set; } = new List<HousePayModel>();

    }
}
