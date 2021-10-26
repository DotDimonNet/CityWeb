using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class PriceModel : Entity
    {
        public double Value { get; set; }
        public double Tax { get; set; } 
        public double VAT { get; set; }
        public double Total => Value * (1 + VAT) + Tax;
        public bool IsValid => Value >= 0 && VAT >= 0 && VAT <= 3;

    }
}
