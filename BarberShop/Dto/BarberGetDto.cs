namespace BarberShop.Dto
{
    public class BarberGetDto
    {
        public string Salon { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public int SubscriptionPeriod { get; set; }
    }
}
