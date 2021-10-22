using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;

namespace CityWeb.Infrastructure.Service
{
    public class EntertainmentService
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        public EntertainmentService(ApplicationContext context, SignInManager<ApplicationUserModel> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        
    }
}
