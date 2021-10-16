using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Common.Repository
{
    public class SyncModel : ISyncModel
    {
        public string TableName { get; set; }
        public List<string> FieldsToSync { get; set; } = new List<string>();
        public List<string> MissedFields { get; set; } = new List<string>();
        public List<string> ExtraFields { get; set; } = new List<string>();
        public bool IsSynchronized { get; set; }
    }
}
