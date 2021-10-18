using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public class HousePaymentType : Enumeration
    {
        public static readonly HousePaymentType Electricity = new(1, "Electricity");
        public static readonly HousePaymentType WaterGet = new(2, "WaterGet");
        public static readonly HousePaymentType WaterOut = new(3, "WaterOut");
        public static readonly HousePaymentType Gas = new(4, "Gas");
        public static readonly HousePaymentType GasTransport = new(5, "GasTransport");
        public static readonly HousePaymentType Intercom = new(6, "Intercom");
        public static readonly HousePaymentType Internet = new(7, "Internet");
        public static readonly HousePaymentType TV = new(8, "Internet");
        public static readonly HousePaymentType Trash = new(9, "Trash");
        public static readonly HousePaymentType Rent = new(10, "Rent");

        protected HousePaymentType(int id, string name) : base(id, name) { }

    }
}