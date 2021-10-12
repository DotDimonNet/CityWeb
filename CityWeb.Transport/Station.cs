using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Transport
{
    class Station
    {
        public string Titlte { get; set; }
        /// <summary>
        /// Minutes to move frome previouse station to current, if first station, minutes = 0
        /// </summary>
        public double MinutesToStation { get; set; }
        public Station(string stationTitle, double minutesToStation)
        {
            Titlte = stationTitle;
            MinutesToStation = minutesToStation;
        }

    }
}
