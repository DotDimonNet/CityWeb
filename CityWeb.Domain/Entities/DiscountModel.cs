using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class DiscountModel : Entity, IDescribe
    {
        public double Value { get; set; }
        public bool IsImmortal { get; set; }
        public DateTime FiredOut { get; set; }
        public string Promocode { get; set; }
        public bool IsReferalBonus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
