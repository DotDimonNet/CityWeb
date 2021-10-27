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
        //step 1
        public string TaxiTitle { get; set; }
        public string TaxiDescription { get; set; }//???
        //step 2
        public ICollection<AddressModel> VisitedAddresses { get; set; } = new List<AddressModel>();
        //step 3
        public TransportType TaxiType { get; set; }
        public PriceModel Price { get; set; }
    }
}
