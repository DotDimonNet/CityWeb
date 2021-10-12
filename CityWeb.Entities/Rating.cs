using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Entities
{
    public class Rating
    {
        public double CurrentRating { get; set; }
        public double GradeSum { get; set; } = 0;
        public int UsersCount { get; set; } = 0;

        public void Rate(double userRate)
        {
            CurrentRating = (GradeSum + userRate) / (UsersCount + 1);
        }


    }
}
