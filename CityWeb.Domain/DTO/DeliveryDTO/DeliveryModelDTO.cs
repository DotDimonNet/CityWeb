
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class SelectDeliveryModelDTO
    {
        public string Title { get; set; }
    }

    public class DeliveryModelDTO
    {
        public Guid DeliveryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeliveryImage { get; set; }
        public PeriodModelDTO WorkShedyle { get; set; }
        public PriceModelDTO DeliveryPrice { get; set; }
    }
}
