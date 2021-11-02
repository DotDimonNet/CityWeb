using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class DiscountModel : Entity
    {
        // Main
        public virtual ApplicationUserModel User { get; set; }
        public virtual ServiceModel Service { get; set; }
        public double Value { get; set; }
        public double DiscountStep { get; set; }
        public double MaxDiscount { get; set; }
        public double SpentMoney { get; set; }  
        //Optional
        public bool IsImmortal { get; set; }
        public DateTime FiredOut { get; set; }
        public string Promocode { get; set; }
        public bool IsReferalBonus { get; set; }
        

    }
}
