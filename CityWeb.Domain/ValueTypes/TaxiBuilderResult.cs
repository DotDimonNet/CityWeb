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
        public Guid Id { get; set; }
        public IEnumerable<AddressModelDTO> VisitedAddresses { get; set; }
        public string TaxiType { get; set; }
        public double Price { get; set; }
    }
}
