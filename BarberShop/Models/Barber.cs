namespace BarberShop.Models
{
    public class Barber : User
    {
        public string Salon { get; set; }
        public string Address { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public int SubscriptionPeriod { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<BarberEmployee> BarberEmployees { get; set; }
        public ICollection<BarberService> BarberServices { get; set; }
    }
}
