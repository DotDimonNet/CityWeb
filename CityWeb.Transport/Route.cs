using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Transport
{
    class Route
    {
        public IEnumerable<Station> Stations { get; set; }
        public IEnumerable<DateTime> StartRoute { get; set; }
        public void AddStartRoute(DateTime startRoute)
        {
            StartRoute.Append(startRoute);
        }
        public void DeleteStartRoute()
        {

        }
        public void AddStation(string stationTitle, double minutesToStation = 0)
        {
            Stations.Append(new Station(stationTitle, minutesToStation));
        }
        public void DeleteStation()
        {

        }
        public double GetTimeBtwnStations(Station startStation, Station endStation)
        {
            return 0;
        }
    }
}
