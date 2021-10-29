using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.RatingDTO
{
    public class RateServiceDTO
    {
        public Guid UserId { get; set; }
        public Guid ServiceId { get; set; }
        public int Rating { get; set; }
    }
}
