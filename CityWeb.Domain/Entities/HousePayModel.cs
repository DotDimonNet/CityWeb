using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class HousePayModel : Entity, IDescribe
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ServiceModel Service { get; set; }
        public virtual Guid ServiceId { get; set; }
        public virtual AddressModel HouseHoldAdress { get; set; }
        public virtual PaymentModel Payments { get; set; }
        public virtual ICollection<CounterModel> CounterModels { get; set; } = new List<CounterModel>();
    }
}
