﻿using CityWeb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public class RentCarModel : Entity
    {
        public virtual TransportType Type { get; set; }
        public string Mark { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public string Number { get; set; }
        public virtual PriceModel Price { get; set; }
        public virtual Guid CarSharingId { get; set; } = Guid.NewGuid();
        public virtual CarSharingModel CarSharing { get; set; }
        //public bool IsFree { get; set; }
        public virtual PeriodModel RentPeriod { get; set; }
    }
}
