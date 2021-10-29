using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.RatingDTO;
using Microsoft.EntityFrameworkCore;

namespace CityWeb.Infrastructure.Service
{
    public class RatingService
    {
        private readonly ApplicationContext _context;
        public RatingService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<RatingModel> RateService(RateServiceDTO rating)
        {
            var newRating = new RatingModel()
            {
                Value = rating.Rating,
                ServiceId = rating.ServiceId,
                UserId = rating.UserId
            };

            var model = await _context.Ratings.AddAsync(newRating);
            await _context.SaveChangesAsync();

            return model.Entity;
        }

        public IEnumerable<RatingModel> FindRatesByUserId(UserRateDTO userRate)
        {
            return _context.Ratings.Where(x => x.UserId == userRate.UserId);
        }

        public async Task<double> FindMaxRating(MaxServiceRateDTO serviceRate)
        {
            return await _context.Ratings
                .Where(x => x.ServiceId == serviceRate.ServiceId).MaxAsync(x => x.Value);
        }
        public async Task<RatingModel> FindMinRating(MinServiceRateDTO serviceRate)
        {
            var service = _context.Ratings.Where(x => x.ServiceId == serviceRate.ServiceId);
            return service.Min();
        }
    }
}
