namespace CityWeb.Domain.Enums
{
    public class PaymentStatus : Enumeration
    {
        public static readonly PaymentStatus Approved = new(1, "Approved");
        public static readonly PaymentStatus Executed = new(2, "Executed");
        public static readonly PaymentStatus Accepted = new(3, "Accepted");
        public static readonly PaymentStatus Discarded = new(4, "Discarded");
        public static readonly PaymentStatus Removed = new(5, "Removed");
        public static readonly PaymentStatus Refunded = new(6, "Refunded");
        public static readonly PaymentStatus Created = new(7, "Created");

        protected PaymentStatus(int id, string name) : base(id, name) { }
    }
}
