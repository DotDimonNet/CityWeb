﻿using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Entities
{
    /*public class TransportJourney : Infrastructure.Interfaces.TransportJourney
    {
        public Guid RatingId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid OwnerId { get; set; }
        public Vehicle Vehicle { get; set; }
        public IEnumerable<Infrastructure.Interfaces.Address> Visited { get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public TransportJourney(Guid userId, Vehicle vehicle, IEnumerable<Infrastructure.Interfaces.Address> addresses, Guid paymentId, Guid ratingId = default)
        {
            OwnerId = userId;
            Vehicle = vehicle;
            Visited = addresses;
            PaymentId = paymentId;
            RatingId = ratingId;
        }

        public string ShortInfo =>
            $"JourneyId: {Id}\tPaymentId: {PaymentId}\t{nameof(OwnerId)}: {OwnerId}\t{nameof(Created)}: {Created}";
        
    }*/
}
