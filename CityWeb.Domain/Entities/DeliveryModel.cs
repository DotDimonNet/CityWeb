﻿using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class DeliveryModel : Entity, IDescribe
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeliveryImage { get; set; }
        public virtual ServiceModel Service { get; set; }
        public virtual Guid ServiceId { get; set; }
        public virtual AddressModel DeliveryAdress { get; set; }
        public virtual PeriodModel WorkSchedule { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
        public virtual PriceModel DeliveryPrice { get; set; }
        public virtual RatingModel Rating { get; set; }
    }
}
