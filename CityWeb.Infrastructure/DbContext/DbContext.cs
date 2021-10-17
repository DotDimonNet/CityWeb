using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Common.Repository
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString;
        private readonly IDbSyncManager _dbSync;


        //TODO: create the same for your objects which will be store in db
        public DbContext(string connectionString, IDbSyncManager dbSync)
        {
            _connectionString = connectionString;
            _dbSync = dbSync;
        }

        public async Task InitializeContext()
        {
            await _dbSync.CreateTables("dbo");
            /*await _dbSync.StartSync();

            if (_dbSync.IsFirst)
            {
                await _dbSync.CreateTables("dbo");
            }*/

            Journeys = new DbCollection<ITransportJourney>(_connectionString);
            EventPaymentHistory = new DbCollection<IEventPaymentHistory>(_connectionString);

            if (_dbSync.IsSynchronized)
            {
                await DataLoadAsync();
            }
            else 
            {
                // Only for test.
                return;
                throw new ArgumentException("Database is not synchronized with current context.");
            }
        }

        private async Task DataLoadAsync()
        {
            await Journeys.Load(nameof(Journeys));
            await EventPaymentHistory.Load(nameof(EventPaymentHistory));
        }

        public IDbCollection<ITransportJourney> Journeys { get; set; }
        public IDbCollection<IEventPaymentHistory> EventPaymentHistory { get; set ; }
    }
}
