using CityWeb.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Service
{
    public class DiscountService
    {
        private readonly ApplicationContext _context;

        public DiscountService(ApplicationContext context)
        {
            _context = context;
        }
    }
}
