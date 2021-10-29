using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class CounterModel : Entity
    {
        public int Number { get; set; }
        public virtual HousePayModel HouseHold { get; set; }
        public virtual HousePaymentType Type { get; set; }
        public virtual Guid HouseId { get; set;}
        public double Price { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }
    }
}
