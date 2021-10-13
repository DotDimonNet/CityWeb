using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Enums
{
    public enum PaymentStatus
    {
        Prepared,
        Approved,
        Executed,
        Accepted,
        Discarded,
        Removed,
        Refunded,
        Created
    }
}
