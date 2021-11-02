using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class CounterModelDTO
    {
        public string Number { get; set; }
        public string TypeOfValue { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }
    }
     
    public class CreateCounterModelDTO
    {
        public string Number { get; set; }
        public double StartCount { get; set; }
        public HousePaymentType Type { get; set; }
    }

    public class SelectCounterModelDTO
    {
        public string Number { get; set; }
    }
    public class DeleteCounterModelDTO
    {
        public string Number { get; set; }
    }
    public class UpdateCounterModelDTO
    {
        public string Number { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }
        public double PriceByItem { get; set; }
    }
}

