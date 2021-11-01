using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class NewsModel : Entity, IDescribe
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public NewsType Type { get; set; }
        public virtual ICollection<NewsItemModel> NewsItems { get; set; } = new List<NewsItemModel>();
        public virtual ICollection<EntertainmentModel> EntertainmentNews {get;set;} = new List<EntertainmentModel>();
        public virtual ICollection<DeliveryModel> DeliveryNews {get;set;} = new List<DeliveryModel>();
        public virtual ICollection<HousePayModel> HousePayNews {get;set;} = new List<HousePayModel>();
        public virtual ICollection<HotelModel> HotelNews {get;set;} = new List<HotelModel>();
        public virtual ICollection<CarSharingModel> CarSharingNews {get;set;} = new List<CarSharingModel>();
        public virtual ICollection<TaxiModel> TaxiNews {get;set;} = new List<TaxiModel>();
        
    }
}
