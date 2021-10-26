using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.Transport.CarSharing
{
    public class RentACarDTO
    {
        public string VINCode { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        //public ICollection<PeriodModel> RentPeriod { get; set; } = new List<PeriodModel>();
    }
}
