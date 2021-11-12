using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class CreateDeliveryModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeliveryImage { get; set; }
        public PeriodModelDTO WorkSchedule { get; set; }
        public PriceModelDTO DeliveryPrice { get; set; }
    }
}
