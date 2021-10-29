using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class RatingServiceTest
    {
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }
    }
}
