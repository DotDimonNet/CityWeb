using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IDiscount : IDescribe, IBaseDBO
    {
        public double Discount { get; set; }
        public bool IsImmortal { get; set; }
        public DateTime FiredOut { get; set; }
        public string Promocode { get; set; }
        public bool IsReferalBonus { get; set; }
        public IEnumerable<string> UsedForServices { get; set; }
    }
}
