using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Transport
{
    class Route
    {
        /// <summary>
        /// All station in this route
        /// </summary>
        public IEnumerable<Station> Stations { get; set; }
        /// <summary>
        /// Start station of this route
        /// </summary>
        public IEnumerable<DateTime> StartRoute { get; set; }
        /// <summary>
        /// Add start station of route
        /// </summary>
        /// <param name="startRoute"></param>
        public void AddStartRoute(DateTime startRoute)
        {
            StartRoute.Append(startRoute);
        }
        public void DeleteStartRoute()
        {

        }
        /// <summary>
        /// Add new station to route
        /// </summary>
        /// <param name="stationTitle"></param>
        /// <param name="minutesToStation"></param>
        public void AddStation(string stationTitle, double minutesToStation = 0)
        {
            Stations.Append(new Station(stationTitle, minutesToStation));
        }
        public void DeleteStation()
        {

        }
        /// <summary>
        /// Return count of minutes to move from startStation to endStation
        /// </summary>
        /// <param name="startStation"></param>
        /// <param name="endStation"></param>
        /// <returns></returns>
        public double GetTimeBtwnStations(Station startStation, Station endStation)
        {
            return 0;
        }
    }
}
