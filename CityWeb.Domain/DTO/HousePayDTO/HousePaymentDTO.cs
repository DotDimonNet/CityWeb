using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class HousePaymentDTO
    {
    public string AccountID {get; set; }
    public double Price { get; set; }

    public double CurrentValue { get; set; }

    public double PaidValue { get; set; }


    }
}
