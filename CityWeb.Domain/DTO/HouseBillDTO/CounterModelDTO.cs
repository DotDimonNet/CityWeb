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
        public string Type { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }
        public double PriceByItem { get; set; }
        public PriceModelDTO Price { get; set; }
    }
    public class CreateCounterModelDTO
    {
        public Guid HouseBillId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }
        public double PriceByItem { get; set; }
    }

    public class SelectCounterModelDTO
    {
        public string Number { get; set; }
    }

    public class DeleteCounterModelDTO
    {
        public Guid Id { get; set; }
    }

    public class UpdateCounterModelDTO
    {
        public Guid CounterId { get; set;}
        public string Type { get; set; }
        public string Number { get; set; }
        public string HouseBillTitle { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }
        public PriceModelDTO Price { get; set; }
    }
}

