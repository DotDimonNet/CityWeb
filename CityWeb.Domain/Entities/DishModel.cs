using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class DishModel : Entity
    {
        public string DishName { get; set; }
        public int DishCount { get; set; }
        public double DishPrice { get; set; }

        public virtual OrderModel Order { get; set; }
    }
}
