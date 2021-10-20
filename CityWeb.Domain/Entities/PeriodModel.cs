using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class PeriodModel : Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
