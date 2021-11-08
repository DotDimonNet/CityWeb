using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public enum EntertainmentType 
    {
        Cinema = 1,
        Fest = 2,
        Exhibition = 3,
        Circus = 4,
        Theatre = 5,
        Club = 6,
        Museum = 7
        //public static readonly EntertainmentType Cinema = new(1, "Cinema");
        //public static readonly EntertainmentType Fest = new(2, "Fest");
        //public static readonly EntertainmentType Exhibition = new(3, "Exhibition");
        //public static readonly EntertainmentType Circus = new(4, "Circus");
        //public static readonly EntertainmentType Theatre = new(5, "Theatre");
        //public static readonly EntertainmentType Club = new(6, "Club");
        //public static readonly EntertainmentType Museum = new(7, "Museum");
        //protected EntertainmentType(int id, string name) : base(id, name) { }
    }
}
