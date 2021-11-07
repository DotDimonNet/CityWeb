using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.DTO
{
    public class ServiceModelDTO
    {
        public  ICollection<ApplicationUserModel> Users { get; set; } = new List<ApplicationUserModel>();
        public  ICollection<EntertainmentModel> Entertaiments { get; set; } = new List<EntertainmentModel>();  
        public virtual ICollection<DeliveryModel> Deliverys { get; set; } = new List<DeliveryModel>();
        public virtual ICollection<HouseBillModel> HouseBills { get; set; } = new List<HouseBillModel>();
        public virtual ICollection<HotelModel> Hotels { get; set; } = new List<HotelModel>();
        public virtual ICollection<CarSharingModel> CarSharing { get; set; } = new List<CarSharingModel>();
        public virtual ICollection<TaxiModel> Taxi { get; set; } = new List<TaxiModel>();
        public Guid ServiceId { get; set; }
    }
}
