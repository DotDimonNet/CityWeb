using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public class TransportType : Enumeration
    {
        public static readonly TransportType CityBus = new(1, "CityBus");
        public static readonly TransportType CityTrum = new(2, "CityTrum");
        public static readonly TransportType CityTrolleybus = new(3, "CityTrolleybus");
        public static readonly TransportType RentCar = new(4, "RentCar");
        public static readonly TransportType RentBycicle = new(5, "RentBycicle");
        public static readonly TransportType RentKickScooter = new(6, "RentKickScooter");
        public static readonly TransportType TaxiEconom = new(7, "TaxiEconom");
        public static readonly TransportType TaxiStandart = new(8, "TaxiStandart");
        public static readonly TransportType TaxiBusiness = new(9, "TaxiBusiness");

        protected TransportType(int id, string name) : base(id, name) { }
    }
}
