using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class BusketModelDTO
    {
        public ICollection<BusketItemModelDTO> Busket { get; set; } = new List<BusketItemModelDTO>();
        public string UserName { get; set; }
        public AddressModel Address { get; set; }
    }

    public class BusketItemModelDTO 
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
