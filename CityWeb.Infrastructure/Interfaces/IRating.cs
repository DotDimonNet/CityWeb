using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IRating : IBaseDBO, IDescribe
    {
        public double Value { get; set; }
        public Guid ServiceId { get; set; }
    }
}
