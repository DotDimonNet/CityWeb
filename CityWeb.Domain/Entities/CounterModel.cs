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
        public double StartCount { get; set; }
        public double EndCount { get; set; }
    }
}
