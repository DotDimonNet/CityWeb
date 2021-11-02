using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class PriceModelDTO
    {
        public double Value { get; set; }
        public double Tax { get; set; }
        public double VAT { get; set; }
    }
}
