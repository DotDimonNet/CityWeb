using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public class EventType : Enumeration
    {
        public static readonly EventType Cinema = new(1, "Cinema");
        public static readonly EventType Fest = new(2, "Fest");
        public static readonly EventType Exhibition = new(3, "Exhibition");
        public static readonly EventType Circus = new(4, "Circus");
        public static readonly EventType Theatre = new(5, "Theatre");
        public static readonly EventType Club = new(6, "Club");
        public static readonly EventType Museum = new(7, "Museum");

        protected EventType(int id, string name) : base(id, name) { }
    }
}
