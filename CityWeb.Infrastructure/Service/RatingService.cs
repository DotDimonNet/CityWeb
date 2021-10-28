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
        public RatingService(ApplicationContext context, SignInManager<ApplicationUserModel> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        //public async Task<RatingModel> RateService(RateServiceDTO rateService)
        //{
        //    var delivery = await _context.Services.FirstOrDefault 
        //    return new RatingModel()
        //    {
        //        Value =
        //    };
        //}
    }
}
