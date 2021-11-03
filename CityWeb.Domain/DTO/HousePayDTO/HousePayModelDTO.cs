using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.DTO
{
    public class HousePayModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CounterModel Counter { get; set; }
        public double Price { get; set; }
    }
    public class CreateHousePayModelDTO
    {
        public string  Title { get; set; }
        public string Description { get; set; }
        public AddressModelDTO Address { get; set; }
    }
    public class SelectHousePayModelDTO
    {
        public string Title { get; set; }
    }
    public class DeleteHousePayModelDTO
    {
        public string Title { get; set; }
    }

    public class UpdateHousePayModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AddressModelDTO Address { get; set; }
    }

}
