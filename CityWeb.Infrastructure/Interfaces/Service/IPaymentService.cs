using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Enums;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IPaymentService : IServiceMetadata
    {
        public IEnumerable<IPayment> Payments { get; set; }
        public (PaymentStatus Status, Guid PaymentId) CreateNewPayment(Guid balanceId, IPrice price);
        public IBalance GetAcceptableBalance(Guid userId, IPrice price);
        public PaymentStatus CheckStatus(Guid paymentId);
        public IEnumerable<IPayment> GetAllPaymentsByDateRange(DateTime startDate, DateTime endData);
        public IEnumerable<IPayment> GetAllPaymentsForUserSince(DateTime date);
        public PaymentStatus DiscardPayment(Guid paymentId);
        public bool RemovePayment(Guid paymentId);
        public IEnumerable<IPayment> GetPaymentsByIds(Guid paymentId);
        public bool CreateTestPaymentForUser(Guid balanceId, IPrice price);
    }   
}

