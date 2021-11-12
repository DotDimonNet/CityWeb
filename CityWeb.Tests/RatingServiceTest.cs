using CityWeb.Domain.DTO.RatingDTO;
using CityWeb.Infrastructure.Service;
using NUnit.Framework;
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

        /*[Test]
        public async Task RateServiceTest()
        {
            var ratingServise = new RatingService(TestHelper.ApplicationContext);
            var serviseId = TestHelper.ApplicationContext.Ratings.FirstOrDefault(x => x.Value == 3);
            var dto = new RateServiceDTO()
            {
                ServiceId = serviseId.ServiceId,
                Rating = serviseId.Value,
            };


        }*/
    }
}
