using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.HotelDTO
{
    public class DeleteHotelDTO
    {
        public string HotelTitle { get; set; }
        public Guid HotelId { get; set; }
    }
}
