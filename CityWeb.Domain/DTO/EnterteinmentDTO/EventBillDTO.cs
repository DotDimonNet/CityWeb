using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class EventBillDTO
    {
        public string EntertainmentTitle { get; set; }
        public EntertainmentType EntertainmentType { get; set; }
        public string EventTitle { get; set; }
        public PriceModel Price { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public BalanceModel Balance { get; set; }


    }
}
