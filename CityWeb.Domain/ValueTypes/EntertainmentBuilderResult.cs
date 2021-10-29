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
        //Step1
        public string EntertainmentTitle { get; set; }
        //Step2
        public string EventTitle { get; set; }
        //Step3
        public BalanceModel Balance { get; set; }
    }
}
