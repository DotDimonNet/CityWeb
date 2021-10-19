using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class OrderModel : Entity
    {
        public virtual ApplicationUserModel User { get; set; }
        public virtual PaymentModel Payment { get; set; }
        public virtual ICollection<DishModel> Dish { get; set; } = new List<DishModel>(); 
    }
}
