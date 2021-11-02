
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

    public class CreateDeliveryModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class DeliveryModelDTO
    {
        public Guid DeliveryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeliveryImage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public double VAT { get; set; }
    }
}
