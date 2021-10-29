using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.RatingDTO;

namespace CityWeb.Infrastructure.Service
{
    public class RatingService
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        public RatingService(ApplicationContext context)
        {
            _context = context;
            
        }

        public async Task<RatingModel> RateService(RateServiceDTO rateService)
        {
            var rating =  _context.Services.FirstOrDefault(x => x.Id == rateService.ServiceId);
            var newRating = new RatingModel()
            {
                Value = rateService.Rating
            };

            var model = await _context.Ratings.AddAsync(newRating);
            _context.SaveChanges();
            return model.Entity;
        }

        public IEnumerable<RatingModel> FindRateByUserId(UserRateDTO userRate)
        {
            return _context.Ratings.Where(x => x.UserId == userRate.UserId);
        }

        public async Task <RatingModel> FindMaxRating(MaxServiceRateDTO serviceRate)
        {
            var service = _context.Ratings.Where(x => x.ServiceId == serviceRate.ServiceId);
            return service.Max();
        }
        public async Task<RatingModel> FindMinRating(MinServiceRateDTO serviceRate)
        {
            var service = _context.Ratings.Where(x => x.ServiceId == serviceRate.ServiceId);
            return service.Min();
        }
    }
}
