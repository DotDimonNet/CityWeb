using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO.Transport.CarSharing
{
    public class CreateCarSharingModelDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AddressModel Location { get; set; }
        //public virtual ServiceModel Service { get; set; }
    }
}