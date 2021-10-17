using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Common.Repository
{
    public class DbSyncManager : IDbSyncManager
    {
        public bool IsSynchronized => SyncTables.All(x => x.IsSynchronized);

        public bool IsFirst { get; set; }
        private IDbRequestManager<IBaseDBO> RequestManager { get; set; }
        private IEnumerable<ISyncModel> SyncTables { get; set; } = new List<SyncModel>();

        public DbSyncManager(string connectionString)
        {
            RequestManager = new DbRequestManager<IBaseDBO>(connectionString);
            var tables = new List<SyncModel>();
            tables.Add(new SyncModel()
            {
                TableName = nameof(IDbContext.Journeys),
                FieldsToSync = new List<string>() { }
            });
            tables.Add(new SyncModel()
            {
                TableName = nameof(IDbContext.EventPaymentHistory),
                FieldsToSync = new List<string>() { }
            });

            SyncTables = tables;
        }

        public async Task CreateTables(string schema)
        {
            var queryJourney = GenerateTableScript(schema, nameof(IDbContext.Journeys), new List<(string Name, string Type, string isNullable)>()
            {
                (nameof(ITransportJourney.OwnerId), "varchar(64)", "not null"),
                (nameof(ITransportJourney.RatingId), "varchar(64)", "not null"),
                (nameof(ITransportJourney.PaymentId), "varchar(64)", "not null"),
                (nameof(ITransportJourney.Id), "uniqueidentifier PRIMARY KEY", "not null"),
                (nameof(ITransportJourney.Created), "datetime", "not null"),
                (nameof(ITransportJourney.Modified), "datetime", "not null"),
                (nameof(ITransportJourney.Vehicle), "varchar(64)", "not null"),
                (nameof(ITransportJourney.Visited), "varchar(64)", "not null")
            });
            
            await RequestManager.SendRequestAsync(queryJourney, null, false);

            var queryEvent = GenerateTableScript(schema, nameof(IDbContext.EventPaymentHistory), new List<(string Name, string Type, string isNullable)>()
            {
                (nameof(IEventPaymentHistory.OwnerId), "varchar(64)", "not null"),
                (nameof(IEventPaymentHistory.RatingId), "varchar(64)", "not null"),
                (nameof(IEventPaymentHistory.PaymentId), "varchar(64)", "not null"),
                (nameof(IEventPaymentHistory.Id), "uniqueidentifier PRIMARY KEY", "not null"),
                (nameof(IEventPaymentHistory.Created), "datetime", "not null"),
                (nameof(IEventPaymentHistory.Modified), "datetime", "not null"),
                (nameof(IEventPaymentHistory.EventType), "varchar(64)", "not null")
            });

            await RequestManager.SendRequestAsync(queryEvent, null, false);
        }

        private string GenerateTableScript(string schema, string tableName, List<(string Name, string Type, string isNullable)> fields)
        {
            return $@"
                IF NOT EXISTS ( 
                    SELECT * FROM sys.tables t 
                    JOIN sys.schemas s ON (t.schema_id = s.schema_id) 
                    WHERE s.name = '{schema}' and t.name = '{tableName}'
                ) 	CREATE TABLE {schema}.{tableName} (         
                        {string.Join(",\n", fields.Select(x => $"{x.Name} {x.Type} {x.isNullable}"))} 
                )
                ";
        }

        public void SetSource(IEnumerable<ISyncModel> tablesToSync, IDbRequestManager<IBaseDBO> requestManager)
        {
            RequestManager = requestManager;
            SyncTables = tablesToSync;
        }

        public async Task StartSync()
        {
            var checkQuery = $@"";

            var tables = await RequestManager.CommonQueryAsync(checkQuery, null, false);

            if (!tables.Any())
            {
                IsFirst = true;
                return;
            }

            var query = $@"";
            var result = await RequestManager.CommonQueryAsync(query, null, false);
            SyncTables = result.Select(x =>
                new SyncModel
                {
                    ExtraFields = x.ExtraFields,
                    FieldsToSync = x.FieldsToSync,
                    IsSynchronized = x.IsSynchronized,
                    TableName = x.TableName,
                    MissedFields = x.MissedFields
                });
        }
    }
}
