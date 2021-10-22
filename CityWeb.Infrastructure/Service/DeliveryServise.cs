using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Service
{
    public class DeliveryServise
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        public DeliveryServise(ApplicationContext context, SignInManager<ApplicationUserModel> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
    //    public async Task<ApplicationUserModel> RegisterUser(DeliveryModelDTO deliveryModel)
    //    {
    //        var user = new DeliveryModel()
    //        {
    //            Title { get; set; }
    //    public string Description { get; set; }
    //    public virtual ServiceModel Service { get; set; }
    //    public virtual Guid ServiceId { get; set; }
    //    public virtual AddressModel DeliveryAdress { get; set; }
    //    public virtual PeriodModel WorkSchedule { get; set; }
    //    public virtual ICollection<ProductModel> Order { get; set; } = new List<ProductModel>();
    //};
    //        var result = await _signInManager.UserManager.CreateAsync(user, registerModel.Password);

    //        if (result.Succeeded)
    //        {
    //            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == registerModel.Email);
    //        }
    //        else
    //        {
    //            throw new Exception("User was not created!");
    //        }
    //    }
    }

}
