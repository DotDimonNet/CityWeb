using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public enum HotelRoomType
    { 
        Lux,
        Delux,
        Premium,
        President,
        Standart,
        Econom,
    }
    /*public class HotelRoomType : Enumeration
    {
        public static readonly HotelRoomType Lux = new(1, "Lux");
        public static readonly HotelRoomType Delux = new(2, "Delux");
        public static readonly HotelRoomType Premium = new(3, "Premium");
        public static readonly HotelRoomType President = new(4, "President");
        public static readonly HotelRoomType Standart = new(5, "Standart");
        public static readonly HotelRoomType Econom = new(6, "Econom");

        protected HotelRoomType(int id, string name) : base(id, name) { }
        


        //better, but need test!
        public static HotelRoomType GetRandomRoomTypeTest()
        {
            FieldInfo[] fields = typeof(HotelRoomType).GetFields(BindingFlags.Static);
            Random rnd = new Random();
            HotelRoomType randomVariable = (HotelRoomType)fields[rnd.Next(fields.Length)].GetValue(null);         
            return randomVariable;
        }
        public static HotelRoomType GetRandomRoomType()
        {
            Random rnd = new Random();
            FieldInfo[] fields = typeof(HotelRoomType).GetFields(BindingFlags.Static);
            switch(rnd.Next(fields.Length))
            {
                case 1: 
                    return HotelRoomType.Delux;
                case 2: 
                    return HotelRoomType.Econom;
                case 3: 
                    return HotelRoomType.Lux;
                case 4: 
                    return HotelRoomType.Premium;
                case 5: 
                    return HotelRoomType.President;
                case 6: 
                    return HotelRoomType.Standart;
                default:
                    return HotelRoomType.Standart;
            }
        }
    }*/
}
