using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.ValueTypes
{
    public class EntertainmentBuilderResult
    {
        public string EntertainmentTitle { get; set; }
        public string EventTitle { get; set; }
        public BalanceModel Balance { get; set; }
    }
}
