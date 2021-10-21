using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class TaxiModel : Entity, IDescribe
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public virtual ServiceModel Service { get; set; }
        //public virtual PaymentModel Payments { get; set; }


        public virtual ICollection<TaxiCarModel> Vehicle { get; set; } = new List<TaxiCarModel>();
        
    }
}
