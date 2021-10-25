using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;

namespace CityWeb.Domain.DTO.EnterteinmentDTO
{
    public class EventDataPaymentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public BalanceModel Balance { get; set; }
    }
}
