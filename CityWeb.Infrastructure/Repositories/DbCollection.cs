﻿using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Common.Repository
{
    public class DbCollection<T> : IDbCollection<T> where T : IBaseDBO
    {
        public IDbRequestManager<T> RequestManager { get; set; }
        public List<T> Collection { get; set; } = new List<T>();

        public DbCollection(string conn)
        {
            RequestManager = new DbRequestManager<T>(conn);
        }

        public async Task Load(string collectionName)
        {
            if (RequestManager != null)
            {
                var query = $"SELECT * FROM {collectionName}";
                Collection = (await RequestManager.SendQueryAsync(query, null, false)).ToList();
            }
        }
    }
}
