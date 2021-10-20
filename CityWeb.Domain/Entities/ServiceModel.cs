using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class ServiceModel : Entity
    {
        public virtual PriceModel Price { get; set; }//?? PaymentModel/ Delete 
        public virtual ICollection<ApplicationUserModel> Users { get; set; } = new List<ApplicationUserModel>();

        //New
        public virtual ICollection<EntertaimentModel> Entertaiments { get; set; } = new List<EntertaimentModel>();
        public virtual ICollection<DiscountModel> Discounts { get; set; } = new List<DiscountModel>();
        public virtual ICollection<DeliveryModel> Deliverys { get; set; } = new List<DeliveryModel>();
        public virtual ICollection<HousePayModel> HousePayments { get; set; } = new List<HousePayModel>();
        public virtual ICollection<HotelModel> Hotels { get; set; } = new List<HotelModel>();
        public virtual ICollection<CarSharingModel> CarSharing { get; set; } = new List<CarSharingModel>();
        public virtual ICollection<TaxiModel> Taxi { get; set; } = new List<TaxiModel>();


    }
}
