using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IPrice : IDescribe
    {
        public double Price { get; set; }
        public double Tax { get; set; }
        public double VAT { get; set; }
        public double Total => Price * (1 + VAT) + Tax;
        public bool IsValid => Price >= 0 && VAT >= 0 && VAT <= 3;
    }
}
