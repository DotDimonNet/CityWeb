using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Common.Repository
{
    public interface IDbSyncManager
    {
        public void SetSource(IEnumerable<ISyncModel> tablesToSync, IDbRequestManager<IBaseDBO> requestManager);
        public Task CreateTables(string schema);
        public Task StartSync();
        public bool IsSynchronized { get; }
        public bool IsFirst { get; set; }
    }
}
