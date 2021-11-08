using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class RentCarModel : Entity
    {
        public TransportType Type { get; set; }
        public string Mark { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public string Number { get; set; }
        public virtual PriceModel Price { get; set; }
        public virtual CarSharingModel CarSharing { get; set; }
        public virtual Guid CarSharingId { get; set; }
        public virtual ICollection<PeriodModel> RentPeriod { get; set; } = new List<PeriodModel>();
    }
}
