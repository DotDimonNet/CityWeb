using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class RatingModel : Entity
    {
        public virtual ApplicationUserModel User { get; set; }
        public double Value { get; set; }
        public virtual ServiceModel Service{ get; set; }
        public virtual Guid ServiceId { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
