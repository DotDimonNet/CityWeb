using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.ValueTypes
{
    public class TaxiBuilderResult
    {
        public string TaxiTitle { get; set; }
        public ICollection<AddressModelDTO> VisitedAddresses { get; set; } = new List<AddressModelDTO>();
        public string TaxiType { get; set; }
        public double Price { get; set; }
    }
}
