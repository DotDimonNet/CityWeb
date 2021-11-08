using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public enum NewsType 
    {
        Entertainment,
        CarSharing,
        Taxi,
        Delivery,
        Hotel,
        HousePay
        //public static readonly NewsType EntertainmentNews = new(1, "EntertainmentNews");
        //public static readonly NewsType CarSharingNews = new(2, "CarSharingNews");
        //public static readonly NewsType TaxiNews = new(3, "TaxiNews");
        //public static readonly NewsType DeliveryNews = new(4, "DeliveryNews");
        //public static readonly NewsType HotelNews = new(5, "HotelNews");
        //public static readonly NewsType HousePayNews = new(6, "HousePayNews");
        //protected NewsType(int id, string name) : base(id, name) { }
    }
}
