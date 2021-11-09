using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Enums;


namespace CityWeb.Domain.DTO.HouseBillDTO
{
    class PaymentTypeDTO
    {
        public string NameValue { get; set; }
        public HouseBillType PaymentType { get; set; }
    }
}
