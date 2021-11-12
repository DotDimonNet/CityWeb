using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CityWeb.Domain.Entities
{
    public class ApplicationUserModel : IdentityUser<Guid>
    {
        public virtual UserProfileModel Profile { get; set; }
        public virtual ICollection<RatingModel> Ratings { get; set; } = new List<RatingModel>();
        public virtual ICollection<BalanceModel> Balances { get; set; } = new List<BalanceModel>();
        public virtual ICollection<PaymentModel> Payments { get; set; } = new List<PaymentModel>();
        public virtual ICollection<ServiceModel> Services { get; set; } = new List<ServiceModel>();
        public virtual ICollection<DeliveryModel> Orders { get; set; } = new List<DeliveryModel>();
        public virtual ICollection<DiscountModel> Discounts { get; set; } = new List<DiscountModel>();
        public virtual ICollection<EntertainmentModel> Events { get; set; } = new List<EntertainmentModel>();

    }

    public class ApplicationUserRole : IdentityRole<Guid>
    {
        public ApplicationUserRole() : base()
        {
        }

        public ApplicationUserRole(string roleName) : base(roleName)
        {
        }
    }
}
