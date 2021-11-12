using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public enum HouseBillType
    {
        Elrctricity,
        WaterIn,
        WaterOut,
        Gas,
        GasTransport
    }
  /*  public class HouseBillType : Enumeration
    {
        public static readonly HouseBillType Electricity = new(1, "Electricity");
        public static readonly HouseBillType WaterGet = new(2, "WaterGet");
        public static readonly HouseBillType WaterOut = new(3, "WaterOut");
        public static readonly HouseBillType Gas = new(4, "Gas");
        public static readonly HouseBillType GasTransport = new(5, "GasTransport");
        public static readonly HouseBillType Intercom = new(6, "Intercom");
        public static readonly HouseBillType Internet = new(7, "Internet");
        public static readonly HouseBillType TV = new(8, "TV");
        public static readonly HouseBillType Trash = new(9, "Trash");
        public static readonly HouseBillType Rent = new(10, "Rent");

        protected HouseBillType(int id, string name) : base(id, name) { }

    }*/
}

