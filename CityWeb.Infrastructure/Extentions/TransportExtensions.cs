using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Extentions
{
    public static class TransportExtensions
    {
        public static bool IsFree(this RentCarModel rentCar, PeriodModel period)
        {
            foreach (var item in rentCar.RentPeriod)
            {
                if (item.StartTime >= period.StartTime && item.StartTime <= period.EndTime
                || item.EndTime >= period.StartTime && item.EndTime <= period.EndTime)
                    return false;
            }
            return true;
        }
    }
}
