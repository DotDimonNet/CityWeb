using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.DTO
{
    public class HouseBillModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CounterModel Counter { get; set; }
        public double Price { get; set; }

        public AddressModelDTO HouseAdress { get; set; }
    }
    public class CreateHouseBillModelDTO
    {
        public string  Title { get; set; }
        public string Description { get; set; }
        public AddressModelDTO Address { get; set; }
    }
    public class SelectHouseBillModelDTO
    {
        public string Title { get; set; }
    }
    public class DeleteHouseBillModelDTO
    {
        public string Title { get; set; }
    }

    public class UpdateHouseBillModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AddressModelDTO Address { get; set; }
    }

}
