using CityWeb.Domain.DTO.NewsDTO;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class NewsModel : Entity
    {
        public virtual NewsType Type { get; set; }
        public virtual ICollection<NewsItemModel> NewsItems { get; set; } = new List<NewsItemModel>();
        public virtual ServiceModel Service { get; set; }
        public virtual Guid ServiceId { get; set; }
        //public virtual ICollection<EntertainmentModel> EntertainmentNews {get;set;} = new List<EntertainmentModel>();
        //public virtual ICollection<DeliveryModel> DeliveryNews {get;set;} = new List<DeliveryModel>();
        //public virtual ICollection<HousePayModel> HousePayNews {get;set;} = new List<HousePayModel>();
        //public virtual ICollection<HotelModel> HotelNews {get;set;} = new List<HotelModel>();
        //public virtual ICollection<CarSharingModel> CarSharingNews {get;set;} = new List<CarSharingModel>();
        //public virtual ICollection<TaxiModel> TaxiNews {get;set;} = new List<TaxiModel>();
    }
}
