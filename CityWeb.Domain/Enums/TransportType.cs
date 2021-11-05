using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    /*public enum TransportType
    {
        Econom,
        Standart,
        Business
    }*/

    public class TransportType : Enumeration
    {
        public static readonly TransportType Econom = new(1, "Econom");
        public static readonly TransportType Standart = new(2, "Standart");
        public static readonly TransportType Business = new(3, "Business");

        protected TransportType(int id, string name) : base(id, name) { }
    }
}
