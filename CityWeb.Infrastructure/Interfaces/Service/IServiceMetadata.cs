using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IServiceMetadata //: IBaseDBO, IDescribe
    {
        public bool IsActive { get; set; }
        public string Version { get; set; }
    }   
}

