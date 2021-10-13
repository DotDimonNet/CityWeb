using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Enums;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IPayment : IBaseDBO
    {
        public Guid OwnerId { get; set; }
        public IDiscount Discount { get; set; }
        public IPrice Price { get; set; }
        public IRating Rating { get; set; }
        public PaymentStatus Status { get; set; }
    }   
}

