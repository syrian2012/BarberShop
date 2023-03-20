namespace BarberShop.Models
{
    public class Barber : User
    {
        public string Salon { get; set; }
        public string Address { get; set; }
        bool IsActive { get; set; }
        public DateOnly? SubscriptionDate { get; set; }
        public int SubscriptionPeriod { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<BarberEmployee> BarberEmployees { get; set; }
    }
}
