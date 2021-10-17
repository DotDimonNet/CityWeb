using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class ServiceBranchModel : Entity, IDescribe
    {
        public virtual ServiceModel Service { get; set; }
        public virtual PriceModel Price { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
