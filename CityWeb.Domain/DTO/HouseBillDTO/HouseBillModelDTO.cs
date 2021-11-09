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

        public AddressModelDTO HouseHoldAddress { get; set; }
    }
    public class CreateHouseBillModelDTO
    {
        public string  Title { get; set; }
        public string Description { get; set; }
        public AddressModelDTO HouseHoldAddress { get; set; }
    }
    public class SelectHouseBillModelDTO
    {
        public Guid HouseBillId{ get; set; }
    }
    public class DeleteHouseBillModelDTO
    {
        public Guid HouseBillId { get; set; }
    }

    public class UpdateHouseBillModelDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AddressModelDTO HouseHoldAddress { get; set; }
    }

}
