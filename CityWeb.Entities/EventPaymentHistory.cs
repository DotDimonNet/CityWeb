using CityWeb.Infrastructure.Enums;
using CityWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Entities
{
    public class EventPaymentHistory : IEventPaymentHistory
    {
        public Guid RatingId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid OwnerId { get; set; }
        public EventType EventType { get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public EventPaymentHistory(Guid userId, EventType type, Guid paymentId, Guid ratingId = default)
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

