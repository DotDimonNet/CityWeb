using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Entertainment.Enums;
using CityWeb.Entertainment.Interfaces;

namespace CityWeb.Entertainment
{
    public class EventPayment : IEventPayment
    {
        public Guid RatingId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid OwnerId { get; set; }
        public EventType EventType { get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public EventPayment(Guid userId, EventType type, Guid paymentId, Guid ratingId = default)
        {
            OwnerId = userId;
            EventType = type;
            PaymentId = paymentId;
            RatingId = ratingId;
        }

        public string ShortInfo =>
            $"JourneyId: {Id}\tPaymentId: {PaymentId}\t{nameof(OwnerId)}: {OwnerId}\t{nameof(Created)}: {Created}";

        
    }
}

