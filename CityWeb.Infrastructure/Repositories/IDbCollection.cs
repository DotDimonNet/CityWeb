using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Common.Repository
{
    public interface IDbCollection<T> where T : IBaseDBO
    {
        public IDbRequestManager<T> RequestManager { get; set; }
        public List<T> Collection { get; set; }
        public Task Load(string collectionName);
    }
}
