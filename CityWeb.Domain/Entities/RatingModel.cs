using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class RatingModel : Entity, IDescribe
    {
        public virtual ApplicationUserModel User { get; set; }
        public double Value { get; set; }
        //public virtual bool Service { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
