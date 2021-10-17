using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class ServiceModel : Entity, IDescribe
    {
        public virtual PriceModel Price { get; set; }
        public virtual ICollection<ServiceBranchModel> Branches { get; set; } = new List<ServiceBranchModel>();
        public virtual ICollection<ApplicationUserModel> Users { get; set; } = new List<ApplicationUserModel>();

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
