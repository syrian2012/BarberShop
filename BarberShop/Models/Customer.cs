namespace BarberShop.Models
{
    public class Customer: User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
