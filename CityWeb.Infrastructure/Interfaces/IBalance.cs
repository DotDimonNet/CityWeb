using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IBalance : IBaseDBO
    {
        public double Balance { get; set; }
        public string AccountProfileId { get; set; }
        public string CardNumber { get; set; }
        public string CardCode { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool IsExpired => ExpirationDate >= DateTime.Now;
        public bool IsValid => IsExpired 
            && CardCode.Length == 3 
            && CardNumber.Length == 16 
            && AccountProfileId != null;

        public string GetInfo();
    }
}
