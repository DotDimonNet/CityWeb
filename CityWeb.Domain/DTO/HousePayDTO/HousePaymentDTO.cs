using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.DTO
{
    public class HousePaymentDTO
    {
        public string AccountID {get; set; }
        public double Price { get; set; }
        public CounterModel Counter { get; set; }
    }
    public class CreateHousePaymentDTO
    {
        public string  Title { get; set; }

    }
    public class DeleteHousePaymentDTO
    {
        public string Title { get; set; }

    }


}
