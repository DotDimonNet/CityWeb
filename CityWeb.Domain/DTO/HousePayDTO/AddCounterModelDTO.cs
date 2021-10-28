using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.HousePayDTO
{
    public class AddCounterModelDTO
    {
        public int Number { get; set; }
        public string TypeOfValue { get; set; }
        public double StartCount { get; set; }
        public double EndCount { get; set; }

    }
}
