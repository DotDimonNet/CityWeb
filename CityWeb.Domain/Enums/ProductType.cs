using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Enums
{
    public class ProductType : Enumeration
    {
        public static readonly ProductType Burgers = new(1, "Burgers");
        public static readonly ProductType FastFood = new(2, "FastFood");
        public static readonly ProductType Salads = new(3, "Salads");
        public static readonly ProductType Sushi = new(4, "Sushi");
        public static readonly ProductType Pizza = new(5, "Pizza");
        public static readonly ProductType AlcoholicDrinks = new(6, "AlcoholicDrinks");
        public static readonly ProductType Sweets = new(7, "Sweets");


        protected ProductType(int id, string name) : base(id, name) { }
    }
    
}
